<template>
  <section class="mb-12 text-center">
    <h1 class="font-weight-light mb-2 headline">
      Sistema de Gerenciamento de Benefícios
    </h1>
  </section>
</template>

<script>
export default {
  name: "VComponent",

  props: {
    heading: {
      type: String,
      default: "",
    },
    link: {
      type: String,
      default: "",
    },
  },
};
</script>
