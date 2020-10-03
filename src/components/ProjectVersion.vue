<template>
  <div>
    <label class="AppVersion">{{ CurrentAppVersion }}</label>
    <!--  <a v-on:click="CheckUpdate()">check updates</a> -->
    <label class="ProjectVersion">{{ H1z1ServerVersion }}</label>
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
    window.open("https://github.com/QuentinGruber/h1z1-server-app/releases");
  }
  data() {
    return {
      CurrentAppVersion: "App version : " + CurrentAppVersion,
      H1z1ServerVersion: "H1z1-server version : " + H1z1ServerVersion,
    };
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.ProjectVersion {
  position: fixed;
  bottom: 1%;
  left: 49%;
}

.AppVersion {
  left: 0;
  position: fixed;
  bottom: 1%;
}
</style>
