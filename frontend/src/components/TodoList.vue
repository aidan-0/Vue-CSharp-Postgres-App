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
  import { ref, onMounted } from 'vue';
  import TodoItem from './TodoItem.vue';
  import axios from 'axios';
  
  const todos = ref([]);
  const newTodo = ref('');
  
  const api = axios.create({
  baseURL: 'http://localhost:5092/api' // Update this to match your backend URL
});
  
  const fetchTodos = async () => {
    try {
      const response = await api.get('/TodoItems');
      todos.value = response.data;
    } catch (error) {
      console.error('Error fetching todos:', error);
    }
  };
  
  onMounted(() => {
    fetchTodos();
  });
  
  const addTodo = async () => {
    if (newTodo.value.trim()) {
      try {
        const response = await api.post('/TodoItems', {
          text: newTodo.value.trim(),
          completed: false,
        });
        todos.value.push(response.data);
        newTodo.value = '';
      } catch (error) {
        console.error('Error adding todo:', error);
      }
    }
  };
  
  const toggleTodo = async (id) => {
    const todo = todos.value.find((item) => item.id === id);
    if (todo) {
      try {
        const updatedTodo = { ...todo, completed: !todo.completed };
        await api.put(`/TodoItems/${id}`, updatedTodo);
        todo.completed = updatedTodo.completed;
      } catch (error) {
        console.error('Error updating todo:', error);
      }
    }
  };
  
  const removeTodo = async (id) => {
    try {
      await api.delete(`/TodoItems/${id}`);
      todos.value = todos.value.filter((item) => item.id !== id);
    } catch (error) {
      console.error('Error deleting todo:', error);
    }
  };
  </script>
  