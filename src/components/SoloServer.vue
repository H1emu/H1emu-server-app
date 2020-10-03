<template>
  <div class="SoloServer">
    <v-btn
      outline
      v-if="store.state.SoloServerLaunched"
      v-on:click="StopSoloServer()"
    >
      Stop SoloServer
    </v-btn>
    <v-btn v-else v-on:click="LaunchSoloServer()">Launch SoloServer</v-btn>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import store from "../store/servers";
let SoloServerWorker: Worker;
@Component
export default class SoloServer extends Vue {
  data() {
    return {
      store: store,
    };
  }
  private LaunchSoloServer() {
    alert("dd");
    SoloServerWorker = new Worker("../servers/SoloServer.js");
    store.commit("SoloServerToggle");
  }
  private StopSoloServer() {
    SoloServerWorker.terminate();
    store.commit("SoloServerToggle");
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.SoloServer {
  margin: 10;
}
.SoloServer h3 {
  margin: 40px 0 0;
}
.SoloServer ul {
  list-style-type: none;
  padding: 0;
}
.SoloServer li {
  display: inline-block;
  margin: 0 10px;
}
.SoloServer a {
  color: #42b983;
}
</style>
