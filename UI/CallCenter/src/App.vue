<script setup>
import AgentTable from './components/AgentTable.vue';
import HelloWorld from './components/HelloWorld.vue'
import TheWelcome from './components/TheWelcome.vue'

import { onMounted, ref } from 'vue';
const items = ref([]);
onMounted(async()=>{
const response = await fetch('https://localhost:7138/api/CallCenterEvent');
items.value = await response.json();
})
</script>

<template>
  
<div>
  <AgentTable :items="items"/>
</div>
</template>

<style scoped>
header {
  line-height: 1.5;
}

.logo {
  display: block;
  margin: 0 auto 2rem;
}

@media (min-width: 1024px) {
  header {
    display: flex;
    place-items: center;
    padding-right: calc(var(--section-gap) / 2);
  }

  .logo {
    margin: 0 2rem 0 0;
  }

  header .wrapper {
    display: flex;
    place-items: flex-start;
    flex-wrap: wrap;
  }
}
</style>
