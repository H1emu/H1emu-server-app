<template>
  <v-container class="InstallPatch" fluid>
    <v-text-field
      placeholder="h1z1 folder path"
      id="directoryPath"
    ></v-text-field>
    <v-btn v-on:click="InstallPatch()">Install patch</v-btn>
  </v-container>
</template>

<script lang="ts">
import Vue from "vue";
import * as jetpack from "fs-jetpack";

export default Vue.extend({
  name: "InstallPatch",
  props: {
    GameFolderPath: {
      type: String,
    },
  },
  methods: {
    InstallPatch() {
      const inputName: any = document.getElementById("directoryPath");
      const Path = inputName?.value;
      //const fuck = fs.readFileSync("patch/ClientConfig.ini", "utf8");
      jetpack.copy("patch/ClientConfig.ini", `${Path}/ClientConfig.ini`);
      // fs.writeFileSync(`${Path}/ClientConfig.ini`, "ddd");
      alert("Patch applied !");
    },
  },
});
</script>

<style scoped>
.InstallPatch {
  padding-top: 60px;
}
</style>
