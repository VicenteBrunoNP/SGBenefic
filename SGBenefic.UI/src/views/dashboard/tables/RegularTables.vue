<template>
  <v-container id="regular-tables" fluid tag="section">
    <base-v-component heading="Simple Tables" link="components/simple-tables" />
    <base-material-card
      color="success"
      icon="mdi-clipboard-plus"
      title="Meus Benefícios"
      class="px-5 py-3"
    >
      <v-data-table
        :headers="headers"
        :items="benefics"
        sort-by="calories"
        class="elevation-1"
      >
        <template v-slot:top>
          <v-toolbar flat>
            <!-- <v-toolbar-title>Meus Benefícios</v-toolbar-title>
            <v-divider class="mx-4" inset vertical></v-divider>
            <v-spacer></v-spacer> -->
            <v-dialog v-model="dialog" max-width="500px">
              <template v-slot:activator="{ on, attrs }">
                <v-container style="padding-top: 3em">
                  <!-- <v-btn
                  color="primary"
                  dark
                  class="mb-2"
                  v-bind="attrs"
                  v-on="on"
                >
                  Novo Benefício
                </v-btn> -->
                  <v-row>
                    <v-col cols="5">
                      <v-text-field
                        class="purple-input"
                        label="CPF/CNPJ"
                        v-model="filter.cpfCnpj"
                        v-mask="'##############'"
                      />
                    </v-col>
                    <v-col cols="6">
                      <v-select
                        v-model="filter.selectBenefic"
                        :items="selectBenefits"
                        item-text="description"
                        item-value="id"
                        label="Benefício"
                        persistent-hint
                        return-object
                        single-line
                      ></v-select>
                    </v-col>
                    <v-col cols="1" class="text-right">
                      <v-btn color="success" @click="loadBenefits">
                        Buscar
                      </v-btn>
                    </v-col>
                  </v-row>
                </v-container>
              </template>
              <v-card>
                <v-card-title>
                  <span class="text-h5">{{ formTitle }}</span>
                </v-card-title>

                <v-card-text>
                  <v-container>
                    <v-row>
                      <v-col cols="12">
                        <v-checkbox
                          v-model="editedItem.beneficioUtilizado"
                          label="Benefício Utilizado?"
                        ></v-checkbox>
                      </v-col>
                      <v-col cols="12">
                        <v-textarea
                          v-model="editedItem.comentario"
                          name="input-7-1"
                          label="Comentário"
                          value="Comentários"
                          hint="Hint text"
                        ></v-textarea>
                      </v-col>
                    </v-row>
                  </v-container>
                </v-card-text>

                <v-card-actions>
                  <v-spacer></v-spacer>
                  <v-btn color="blue darken-1" text @click="close">
                    Cancelar
                  </v-btn>
                  <v-btn color="blue darken-1" text @click="save">
                    Salvar
                  </v-btn>
                </v-card-actions>
              </v-card>
            </v-dialog>
            <v-dialog v-model="dialogDelete" max-width="500px">
              <v-card>
                <v-card-title class="text-h5"
                  >Tem certeza de que deseja excluir este
                  Benefício?</v-card-title
                >
                <v-card-actions>
                  <v-spacer></v-spacer>
                  <v-btn color="blue darken-1" text @click="closeDelete"
                    >Cancel</v-btn
                  >
                  <v-btn color="blue darken-1" text @click="deleteItemConfirm"
                    >OK</v-btn
                  >
                  <v-spacer></v-spacer>
                </v-card-actions>
              </v-card>
            </v-dialog>
          </v-toolbar>
        </template>
        <template v-slot:item.actions="{ item }">
          <v-icon small class="mr-2" @click="editItem(item)">
            mdi-pencil
          </v-icon>
          <v-icon small @click="deleteItem(item)"> mdi-delete </v-icon>
        </template>
        <template v-slot:no-data>
          <v-btn color="primary" @click="loadBenefits"> Reset </v-btn>
        </template>
      </v-data-table>
    </base-material-card>
  </v-container>
</template>
<script>
import moment from "moment";
import axios from "axios";
export default {
  data() {
    return {
      dialog: false,
      dialogDelete: false,
      headers: [
        // {
        //   text: "Dessert (100g serving)",
        //   align: "start",
        //   sortable: false,
        //   value: "name",
        // },
        { text: "Id", value: "id" },
        { text: "CPF/CNPJ", value: "cpfCnpj" },
        { text: "Razão Social", value: "razaoSocial" },
        { text: "Nível", value: "nivel" },
        { text: "Cód. Benefício", value: "codigoBeneficio" },
        { text: "Benefício", value: "beneficio" },
        { text: "Cód. Organização", value: "orgCod" },
        { text: "Data Concessão", value: "dataConcessaoBeneficio" },
        { text: "Data Validade", value: "dataValidadeBeneficio" },
        {
          text: "Data Utilização",
          value: "dataUtilizacaoBeneficio",
        },
        { text: "Utilizado?", value: "beneficioUtilizado" },
        { text: "Comentário", value: "comentario" },
        { text: "Ações", value: "actions", sortable: false },
      ],
      benefics: [],
      filter: {
        cpfCnpj: "",
        selectBenefic: { id: "", description: "" },
      },
      selectBenefits: {},
      editedIndex: -1,
      editedItem: {
        name: "",
      },
      defaultItem: {
        name: "",
      },
    };
  },
  computed: {
    formTitle() {
      return this.editedIndex === -1 ? "Novo Benefício" : "Editar Benefício";
    },
  },
  watch: {
    dialog(val) {
      val || this.close();
    },
    dialogDelete(val) {
      val || this.closeDelete();
    },
  },
  methods: {
    loadBenefits() {
      axios
        .get(
          `http://localhost:5000/api/Beneficit?cpfCnpj=${this.filter.cpfCnpj}&codigoBeneficio=${this.filter.selectBenefic.id}`
        )
        .then((response) => {
          let _benefics = [];
          response.data.forEach(function (item) {
            if (item.dataConcessaoBeneficio)
              item.dataConcessaoBeneficio = moment(
                item.dataConcessaoBeneficio
              ).format("DD/MM/YYYY");

            if (item.dataUtilizacaoBeneficio)
              item.dataUtilizacaoBeneficio = moment(
                item.dataUtilizacaoBeneficio
              ).format("DD/MM/YYYY");

            if (item.dataValidadeBeneficio)
              item.dataValidadeBeneficio = moment(
                item.dataValidadeBeneficio
              ).format("DD/MM/YYYY");

            item.beneficioUtilizado =
              item.beneficioUtilizado == 0 ? true : false;

            _benefics.push(item);
          });

          this.benefics = _benefics;
        });
    },
    loadSelectBenefits() {
      axios
        .get("http://localhost:5000/api/Beneficit/GetOnlyBeneficits")
        .then((response) => {
          this.selectBenefits = response.data;
        });
    },

    editItem(item) {
      this.editedIndex = this.benefics.indexOf(item);
      this.editedItem = Object.assign({}, item);
      this.dialog = true;
      console.log("ITEM", item);
    },

    deleteItem(item) {
      this.editedIndex = this.benefics.indexOf(item);
      this.editedItem = Object.assign({}, item);
      this.dialogDelete = true;
    },

    deleteItemConfirm() {
      console.log("DELETE", this.benefics[this.editedIndex]);

      this.benefics.splice(this.editedIndex, 1);
      this.closeDelete();
    },

    close() {
      this.dialog = false;
      this.$nextTick(() => {
        this.editedItem = Object.assign({}, this.defaultItem);
        this.editedIndex = -1;
      });
    },

    closeDelete() {
      this.dialogDelete = false;
      this.$nextTick(() => {
        this.editedItem = Object.assign({}, this.defaultItem);

        this.editedIndex = -1;
      });
    },

    save() {
      if (this.editedIndex > -1) {
        Object.assign(this.benefics[this.editedIndex], this.editedItem);
        console.log("Editou", this.benefics[this.editedIndex], this.editedItem);
      } else {
        this.benefics.push(this.editedItem);
        console.log("Add", this.editedItem);
      }
      this.close();
    },
  },
  created() {
    this.loadBenefits();
    this.loadSelectBenefits();
  },
};
</script>
