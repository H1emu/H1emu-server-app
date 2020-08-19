<template>
  <div id="LoginServer">
    <h1>LoginServer</h1>
    <label>server port :</label>
    <input type="text" id="ServerPort_LoginServer" />
    <label>Login Key :</label>
    <input type="text" id="LoginKey_LoginServer" />
    <label>
      <input
        type="checkbox"
        name="Use_MongoDb"
        id="Use_MongoDb_LoginServer"
      />using MongoDB
    </label>
    <button v-on:click="LaunchLoginServer()">Launch LoginServer</button>
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

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
#LoginServer {
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
