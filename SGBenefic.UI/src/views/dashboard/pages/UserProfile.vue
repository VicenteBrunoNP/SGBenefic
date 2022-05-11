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
  </v-container>
</template>

<script>
export default {
  data() {
    return {
      nome: "Nome",
      email: "email@email.com",
      password: "",
      role: "Operador",
      roles: ["Operador", "Supervisor", "Administrador"],
    };
  },
};
</script>
