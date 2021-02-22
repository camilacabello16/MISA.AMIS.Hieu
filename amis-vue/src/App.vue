<template>
  <div class="wp-page">
    <Menu />
    <div class="page-right">
        <Header />
        <Content />
    </div>
  </div>
</template>

<script>
import './assets/css/main.css';
import Menu from './components/layout/Menu';
import Header from './components/layout/Header';
import Content from './components/layout/Content';

export default {
  name: 'App',
  components: {
    Menu,
    Header,
    Content
  }
}
</script>

<style>
</style>
