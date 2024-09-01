<script lang="ts" setup>
interface Product {
  id: number;
  name: string;
}

const products = ref<Product[]>([]);

onMounted(() => {
  setTimeout(() => {
    products.value = [
      { id: 1, name: 'Produto 1' },
      { id: 2, name: 'Produto 2' },
      { id: 3, name: 'Produto 3' },
      { id: 4, name: 'Produto 4' }
    ];
  }, 1000);
});

</script>
<template>
  <div>
    Agenda
  </div>
  <div class="card">
    <DataTable :value="products" tableStyle="min-width: 50rem">
      <Column field="id" header="ID"></Column>
      <Column field="name" header="Name"></Column>
    </DataTable>
  </div>
  <div class="card sm:flex sm:justify-center">
    <OrderList v-model="products" dataKey="id">
      <template #item="{ item }">
        {{ item.name }}
      </template>
    </OrderList>
  </div>
</template>

<style scoped></style>