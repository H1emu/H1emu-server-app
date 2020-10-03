<template>
  <div id="LoginServer">
    <button v-on:click="LaunchLoginServer()">Install patch</button>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";

@Component
export default class LoginServer extends Vue {
  private LaunchLoginServer() {
    const myWorker = new Worker("../servers/LoginServer.js");
  }
}
</script>

<style scoped>

</style>
