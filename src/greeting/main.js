import Greeting from "./Greeting.svelte";

var demoApp = new Greeting({
  target: document.querySelector("main")
});

export default demoApp;