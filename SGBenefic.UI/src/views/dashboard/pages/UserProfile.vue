<template>
  <v-container id="user-profile" fluid tag="section">
    <v-row justify="center">
      <v-col cols="12" md="8">
        <base-material-card>
          <template v-slot:heading>
            <div class="display-2 font-weight-light">Perfil do Usuário</div>

            <div class="subtitle-1 font-weight-light">Complete o Perfil</div>
          </template>

          <v-form>
            <v-container class="py-0">
              <v-row>
                <v-col cols="12" md="12">
                  <v-text-field
                    class="purple-input"
                    label="Nome"
                    v-model="nome"
                  />
                </v-col>

                <v-col cols="12" md="6">
                  <v-text-field
                    label="Email"
                    type="email"
                    class="purple-input"
                    v-model="email"
                  />
                </v-col>

                <v-col cols="12" md="6">
                  <v-text-field
                    label="Senha"
                    type="password"
                    class="purple-input"
                    v-model="password"
                  />
                </v-col>

                <v-col cols="12" md="6">
                  <v-select
                    :items="roles"
                    v-model="role"
                    label="Perfil"
                    class="purple-input"
                    dense
                  ></v-select>
                </v-col>

                <v-col cols="12" class="text-right">
                  <v-btn color="success" class="mr-0"> Salvar </v-btn>
                </v-col>
              </v-row>
            </v-container>
          </v-form>
        </base-material-card>
      </v-col>

      <v-col cols="12" md="4">
        <base-material-card
          class="v-card-profile"
          avatar="https://w7.pngwing.com/pngs/481/915/png-transparent-computer-icons-user-avatar-woman-avatar-computer-business-conversation.png"
        >
          <v-card-text class="text-center">
            <h6 class="display-1 mb-1 grey--text">Função</h6>

            <h4 class="display-2 font-weight-light mb-3 black--text">
              {{ nome }}
            </h4>

            <p class="font-weight-light grey--text">Descrição</p>
          </v-card-text>
        </base-material-card>
      </v-col>
    </v-row>
    <v-row>
      <v-col v-col cols="12">
        <base-material-card
          color="info"
          icon="mdi-account-group"
          title="Usuários"
          class="px-5 py-3"
        >
          <v-data-table
            :headers="headers"
            :items="users"
            sort-by="calories"
            class="elevation-1"
          >
            <template v-slot:top>
              <v-toolbar flat>
                <v-dialog v-model="dialog" max-width="500px">
                  <template v-slot:activator="{ on, attrs }">
                    <v-container style="padding-top: 3em">
                      <v-row>
                        <v-col cols="1">
                          <v-btn
                            color="primary"
                            dark
                            class="mb-2"
                            v-bind="attrs"
                            v-on="on"
                          >
                            Novo &nbsp;
                            <v-icon color="white"> mdi-account-plus </v-icon>
                          </v-btn>
                        </v-col>
                        <v-col cols="10">
                          <v-text-field
                            class="purple-input"
                            label="Usuário"
                            v-model="filter.valueFind"
                            color="info"
                          />
                        </v-col>
                        <v-col cols="1">
                          <v-btn color="info" @click="loadUsers">
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
                            <v-text-field
                              class="purple-input"
                              label="Usuário"
                              v-model="editedItem.name"
                              color="info"
                            />
                          </v-col>
                          <v-col cols="12">
                            <v-text-field
                              class="purple-input"
                              label="Email"
                              v-model="editedItem.email"
                              color="info"
                            />
                          </v-col>
                          <v-col cols="12">
                            <v-text-field
                              v-model="editedItem.password"
                              :append-icon="
                                showPassword ? 'mdi-eye' : 'mdi-eye-off'
                              "
                              :rules="[
                                rulesPassword.required,
                                rulesPassword.min,
                              ]"
                              :type="showPassword ? 'text' : 'password'"
                              label="Senha"
                              hint="Pelo Menos 5 Caracteres"
                              counter
                              @click:append="showPassword = !showPassword"
                              class="purple-input"
                              color="info"
                            ></v-text-field>
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
                      <v-btn
                        color="blue darken-1"
                        text
                        @click="deleteItemConfirm"
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
          </v-data-table>
        </base-material-card>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
import moment from "moment";
import axios from "axios";
export default {
  data() {
    return {
      nome: "",
      email: "",
      password: "",
      role: "Operador",
      roles: ["Operador", "Supervisor", "Administrador"],

      /* --- Usuários -- */
      dialog: false,
      dialogDelete: false,
      headers: [
        { text: "Id", value: "id" },
        { text: "Nome", value: "name" },
        { text: "Email", value: "email" },
        { text: "Tipo", value: "role" },
        { text: "Ações", value: "actions", sortable: false },
      ],
      showPassword: false,
      rulesPassword: {
        required: (value) => !!value || "Obrigatório.",
        min: (v) => v.length >= 5 || "Mínimo 5 Caracteres",
      },
      users: [],
      filter: {
        valueFind: "",
      },
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
      return this.editedIndex === -1 ? "Novo Usuário" : "Editar Usuário";
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
    loadUsers() {
      axios
        .get(
          `http://localhost:5000/api/User?valueFind=${this.filter.valueFind}`
        )
        .then((response) => {
          this.users = response.data;
        });
    },
    editItem(item) {
      this.editedIndex = this.users.indexOf(item);
      this.editedItem = Object.assign({}, item);
      this.dialog = true;
      console.log("ITEM", item);
    },

    deleteItem(item) {
      this.editedIndex = this.users.indexOf(item);
      this.editedItem = Object.assign({}, item);
      this.dialogDelete = true;
    },

    deleteItemConfirm() {
      console.log("DELETE", this.users[this.editedIndex]);

      this.users.splice(this.editedIndex, 1);
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
        Object.assign(this.users[this.editedIndex], this.editedItem);
        console.log("Editou", this.users[this.editedIndex], this.editedItem);
      } else {
        this.users.push(this.editedItem);
        console.log("Add", this.editedItem);
      }
      this.close();
    },
  },
  beforeMount() {
    this.nome = this.$store.state.usuario.name;
    this.email = this.$store.state.usuario.email;
  },
  created() {
    this.loadUsers();
  },
};
</script>
