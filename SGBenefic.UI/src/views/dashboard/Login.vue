<template>
  <v-app>
    <p>{{ $store.state.login }}</p>
    <v-container fluid class="lighten-5" v-if="$store.state.login == false">
      <v-row no-gutters>
        <v-col cols="3"></v-col>
        <v-col cols="6">
          <form>
            <v-text-field
              v-model="login.email"
              :rules="emailRules"
              label="E-mail"
              required
            ></v-text-field>
            <v-text-field
              v-model="login.password"
              :append-icon="showPassword ? 'mdi-eye' : 'mdi-eye-off'"
              :rules="[rules.required, rules.min]"
              :type="showPassword ? 'text' : 'password'"
              label="Senha"
              hint="Pelo Menos 8 caracteres"
              counter
              @click:append="showPassword = !showPassword"
            ></v-text-field>

            <v-card-actions>
              <v-btn depressed color="primary" @click.prevent="logar">
                Entrar
              </v-btn>
            </v-card-actions>
            <v-card-actions>
              <p>
                <a href="/" target="_blank">Perdeu a Senha? Clique aqui</a>
              </p>
            </v-card-actions>
          </form>
        </v-col>
        <v-col cols="3"></v-col>
      </v-row>
    </v-container>

    <!-- <LoginCriar /> -->
  </v-app>
</template>

<script>
import LoginCriar from "@/views/dashboard/LoginCriar.vue";
export default {
  name: "Login",
  components: {
    LoginCriar,
  },
  data() {
    return {
      showPassword: false,
      login: {
        email: "usuario1@hotmail.com",
        password: "12345678",
      },
      emailRules: [
        (v) => !!v || "E-mail é Obrigatório",
        (v) => /.+@.+/.test(v) || "E-mail inválido",
      ],
      rules: {
        required: (value) => !!value || "Obrigatório.",
        min: (v) => v.length >= 8 || "Mínimo 8 Caracteres",
      },
    };
  },
  methods: {
    logar() {
      let self = this;
      this.$store.dispatch("getUser", self.login.email);
      this.$router.push("/");
    },
    VerifyLogin() {
      if (this.$store.state.login) {
        console.log("JÁ LOGADO");
        this.$router.push("/");
      }
    },
  },
  beforeMount() {
    this.VerifyLogin();
  },
};
</script>

<style scoped>
body {
  background: #f0f;
}
</style>
