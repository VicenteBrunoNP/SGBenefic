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
                <v-btn
                  color="primary"
                  dark
                  class="mb-2"
                  v-bind="attrs"
                  v-on="on"
                >
                  Novo Benefício
                </v-btn>
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
                          v-model="selected"
                          label="Benefício Utilizado"
                          value="Benefício Utilizado"
                        ></v-checkbox>
                      </v-col>
                      <v-col cols="12">
                        <v-textarea
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
                    Cancel
                  </v-btn>
                  <v-btn color="blue darken-1" text @click="save"> Save </v-btn>
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
          <v-btn color="primary" @click="loadOrder"> Reset </v-btn>
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
        { text: "CPF/CNPJ", value: "CPF_CNPJ" },
        { text: "Razão Social", value: "RAZAO_SOCIAL" },
        { text: "Nível", value: "NIVEL" },
        { text: "Cód. Benefício", value: "CODIGO_BENEFICIO" },
        { text: "Benefício", value: "BENEFICIO" },
        { text: "Cód. Organização", value: "ORG_COD" },
        { text: "Data Concessão", value: "DATA_CONCESSAO_BENEFICIO" },
        { text: "Data Validade", value: "DATA_VALIDADE_BENEFICIO" },
        {
          text: "Data Utilização",
          value: "DATA_UTILIZACAO_BENEFICIO",
        },
        { text: "Utilizado?", value: "BENEFICIO_UTILIZADO" },
        { text: "Comentário", value: "COMENTARIO" },
        { text: "Ações", value: "actions", sortable: false },
      ],
      benefics: [],
      editedIndex: -1,
      editedItem: {
        name: "",
        calories: 0,
        fat: 0,
        carbs: 0,
        protein: 0,
      },
      defaultItem: {
        name: "",
        calories: 0,
        fat: 0,
        carbs: 0,
        protein: 0,
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
    loadOrder() {
      axios.get(`"http://localhost:5000/api/Beneficit"`).then((response) => {
        let _benefics = [];
        response.data.forEach(function (item) {
          if (item.DATA_CONCESSAO_BENEFICIO)
            item.DATA_CONCESSAO_BENEFICIO = moment(
              item.DATA_CONCESSAO_BENEFICIO
            ).format("DD/MM/YYYY");

          if (item.DATA_UTILIZACAO_BENEFICIO)
            item.DATA_UTILIZACAO_BENEFICIO = moment(
              item.DATA_UTILIZACAO_BENEFICIO
            ).format("DD/MM/YYYY");

          if (item.DATA_VALIDADE_BENEFICIO)
            item.DATA_VALIDADE_BENEFICIO = moment(
              item.DATA_VALIDADE_BENEFICIO
            ).format("DD/MM/YYYY");

          _benefics.push(item);
        });

        this.benefics = _benefics;
      });
    },

    editItem(item) {
      this.editedIndex = this.benefics.indexOf(item);
      this.editedItem = Object.assign({}, item);
      this.dialog = true;
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
    this.loadOrder();
  },
};
</script>
