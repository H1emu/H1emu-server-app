<template>
  <div>
    <label>
      {{ CurrentAppVersion }}
    </label>
    <a v-on:click="CheckUpdate()">
      check updates
    </a>
    <br />
    <br />
    <label>{{ H1z1ServerVersion }}</label>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import ProjectSetting from "../../package.json";
const CurrentAppVersion = ProjectSetting.version;
const H1z1ServerVersion = ProjectSetting.dependencies["h1z1-server"];
@Component
export default class LoginServer extends Vue {
  private CheckUpdate() {
    window.open("https://github.com/QuentinGruber/h1z1-server-app/release");
  }
  data() {
    return {
      CurrentAppVersion: "App version : " + CurrentAppVersion,
      H1z1ServerVersion: "Used h1z1-server version : " + H1z1ServerVersion,
    };
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
