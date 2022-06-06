<template>
  <v-app>
    <div v-if="$store.state.login">
      <dashboard-core-app-bar />
      <dashboard-core-drawer />
    </div>

    <dashboard-core-view />

    <!-- <dashboard-core-settings /> -->
  </v-app>
</template>

<script>
export default {
  name: "DashboardIndex",

  components: {
    DashboardCoreAppBar: () => import("./components/core/AppBar"),
    DashboardCoreDrawer: () => import("./components/core/Drawer"),
    DashboardCoreSettings: () => import("./components/core/Settings"),
    DashboardCoreView: () => import("./components/core/View"),
  },

  data: () => ({
    expandOnHover: false,
  }),
  methods: {
    VerifyLogin() {
      if (!this.$store.state.login) {
        console.log("NÃO LOGADO");
        this.$router.push("/login");
      }
    },
  },
  beforeMount() {
    this.VerifyLogin();
  },
};
</script>
