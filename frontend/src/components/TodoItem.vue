<template>
    <li>
      <input
        type="checkbox"
        v-model="todo.completed"
        @change="$emit('toggle', todo.id)"
      />
      <span :class="{ completed: todo.completed }">{{ todo.text }}</span>
      <button @click="$emit('remove', todo.id)">Delete</button>
    </li>
  </template>
  
  <script setup>
  defineProps({
    todo: Object,
  });
  </script>
  
  <style scoped>
  .completed {
    text-decoration: line-through;
  }
  </style>