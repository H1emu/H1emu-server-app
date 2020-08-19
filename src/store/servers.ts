import Vue from "vue";
import Vuex from "vuex";

Vue.use(Vuex);

interface State {
  SoloServerLaunched: boolean;
}
// Accesible with $store.state.count
const state = {
  SoloServerLaunched: false,
};

export default new Vuex.Store({
  state,
  mutations: {
    SoloServerToggle(state: State) {
      if (state.SoloServerLaunched) {
        state.SoloServerLaunched = false;
      } else {
        state.SoloServerLaunched = true;
      }
    },
  },
});
