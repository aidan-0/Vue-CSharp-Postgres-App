<template>
    <div>
      <input
        v-model="newTodo"
        @keyup.enter="addTodo"
        placeholder="Add a new todo"
      />
      <ul>
        <TodoItem
          v-for="todo in todos"
          :key="todo.id"
          :todo="todo"
          @toggle="toggleTodo"
          @remove="removeTodo"
        />
      </ul>
    </div>
  </template>
  
  <script setup>
  import { ref } from 'vue';
  import TodoItem from './TodoItem.vue';
  
  const todos = ref([]);
  const newTodo = ref('');
  
  const addTodo = () => {
    if (newTodo.value.trim()) {
      todos.value.push({
        id: Date.now(),
        text: newTodo.value,
        completed: false,
      });
      newTodo.value = '';
    }
  };
  
  const toggleTodo = (id) => {
      const todo = todos.value.find((item) => item.id === id);
      if (todo) todo.completed === !todo.completed;
  };
  
  const removeTodo = (id) => {
    todos.value = todos.value.filter((item) => item.id !== id);
  };
  </script>