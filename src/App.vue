<template>
  <div id="app">
    <SoloServer />
    <ProjectVersion />
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import SoloServer from "./components/SoloServer.vue";
import ProjectVersion from "./components/ProjectVersion.vue";

@Component({
  components: {
    SoloServer,
    ProjectVersion,
  },
})
export default class App extends Vue {}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
::-webkit-scrollbar {
  display: none;
}
</style>
