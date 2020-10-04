<template>
  <header id="titlebar">
    <div id="drag-region">
      <div class="button" id="min-button">
        <img
          class="icon"
          src="../assets/icons/min-w-24.png"
          draggable="false"
        />
      </div>
      <div @click="ExitApp()" class="button" id="close-button">
        <img
          class="icon"
          src="../assets/icons/close-w-24.png"
          draggable="false"
        />
      </div>
    </div>
  </header>
</template>

<style scoped>
#titlebar {
  display: flex;
  position: fixed;
  height: 32px;
  width: calc(100%);
  background: #254053;
}

#titlebar #drag-region {
  width: 85%;
  height: 100%;
  -webkit-app-region: drag;
}

#close-button:hover {
  background: #e81123 !important;
}

#close-button:active {
  background: #f1707a !important;
}
#close-button {
  position: fixed;
  top: 1%;
  right: 1%;
}
#min-button:hover {
  background: #395569 !important;
}

#min-button:active {
  background: #4d6f88 !important;
}
#min-button {
  position: fixed;
  top: 1%;
  right: 10%;
}
</style>

<script lang="ts">
import Vue from "vue";
export default Vue.extend({
  methods: {
    MinimizeApp() {
      // TODO : event emit minimize
    },
    ExitApp() {
      // TODO : event emit close
    },
  },
});
</script>
