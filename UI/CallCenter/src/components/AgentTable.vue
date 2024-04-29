<script setup>
import { defineProps, ref, computed } from 'vue';

const props = defineProps({
    items: {
        type: Array
    }
});

const sortByColumn = ref(null);
const sortDirection = ref('asc');

const sortedItems = computed(() => {
  if (!sortByColumn.value) return props.items;

  return [...props.items].sort((a, b) => {
    const valueA = a[sortByColumn.value];
    const valueB = b[sortByColumn.value];

    if (typeof valueA === 'number' && typeof valueB === 'number') {
      return sortDirection.value === 'asc' ? valueA - valueB : valueB - valueA;
    } else {
      const comparison = String(valueA).localeCompare(String(valueB));
      return sortDirection.value === 'asc' ? comparison : -comparison;
    }
  });
});

const sortBy = (column) => {
  if (sortByColumn.value === column) {
    sortDirection.value = sortDirection.value === 'asc' ? 'desc' : 'asc';
  } else {
    sortByColumn.value = column;
    sortDirection.value = 'asc'; // Default to ascending when changing column
  }
};

</script>

<template>
    <div>
        <h1>Agent Information</h1>
    </div>
    <table>
        <thead>
            <tr>
                <th @click="sortBy('id')">ID</th>
                <th @click="sortBy('agentName')">Agent Name</th>
                <th @click="sortBy('agentState')">Agent State</th>
                <th @click="sortBy('timestampUtc')">Time Stamp</th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="item in sortedItems" :key="item.id">
            <td>{{ item.id }}</td>
            <td>{{ item.agentName }}</td>
            <td>{{ item.agentState }}</td>
            <td>{{ item.timestampUtc }}</td>
        </tr>
        </tbody>
    </table>
</template>

<style>
body {
	background: #fafafa url(https://jackrugile.com/images/misc/noise-diagonal.png);
	color: #444;
	font: 100%/30px 'Helvetica Neue', helvetica, arial, sans-serif;
	text-shadow: 0 1px 0 #fff;
}

strong {
	font-weight: bold; 
}

em {
	font-style: italic; 
}

table {
	background: #f5f5f5;
	border-collapse: separate;
	box-shadow: inset 0 1px 0 #fff;
	font-size: 12px;
	line-height: 24px;
	margin: 30px auto;
	text-align: left;
	width: 800px;
}	

th {
	background: url(https://jackrugile.com/images/misc/noise-diagonal.png), linear-gradient(#777, #444);
	border-left: 1px solid #555;
	border-right: 1px solid #777;
	border-top: 1px solid #555;
	border-bottom: 1px solid #333;
	box-shadow: inset 0 1px 0 #999;
	color: #fff;
  font-weight: bold;
	padding: 10px 15px;
	position: relative;
	text-shadow: 0 1px 0 #000;	
}

th:after {
	background: linear-gradient(rgba(255,255,255,0), rgba(255,255,255,.08));
	content: '';
	display: block;
	height: 25%;
	left: 0;
	margin: 1px 0 0 0;
	position: absolute;
	top: 25%;
	width: 100%;
}

th:first-child {
	border-left: 1px solid #777;	
	box-shadow: inset 1px 1px 0 #999;
}

th:last-child {
	box-shadow: inset -1px 1px 0 #999;
}

td {
	border-right: 1px solid #fff;
	border-left: 1px solid #e8e8e8;
	border-top: 1px solid #fff;
	border-bottom: 1px solid #e8e8e8;
	padding: 10px 15px;
	position: relative;
	transition: all 300ms;
}

td:first-child {
	box-shadow: inset 1px 0 0 #fff;
}	

td:last-child {
	border-right: 1px solid #e8e8e8;
	box-shadow: inset -1px 0 0 #fff;
}	

tr {
	background: url(https://jackrugile.com/images/misc/noise-diagonal.png);	
}

tr:nth-child(odd) td {
	background: #f1f1f1 url(https://jackrugile.com/images/misc/noise-diagonal.png);	
}

tr:last-of-type td {
	box-shadow: inset 0 -1px 0 #fff; 
}

tr:last-of-type td:first-child {
	box-shadow: inset 1px -1px 0 #fff;
}	

tr:last-of-type td:last-child {
	box-shadow: inset -1px -1px 0 #fff;
}	

</style>