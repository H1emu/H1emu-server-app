<template>
  <div id="SoloServer">
    <h1>Solo Server</h1>
    <label>server port :</label>
    <input type="text" id="ServerPort_SoloServer" value="1115" readonly />
    <br />
    <button v-if="store.state.SoloServerLaunched" v-on:click="StopSoloServer()">
      Stop SoloServer
    </button>
    <button v-else v-on:click="LaunchSoloServer()">Launch SoloServer</button>
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
#SoloServer {
  margin: 10;
}
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
</style>
