<script setup lang="ts">
const items = [{
  label: 'Como posso agendar um horário?',
  content: 'Você pode agendar um horário através do nosso site, menu "Agenda".'
}, {
  label: 'Quais são os métodos de pagamento aceitos?',
  content: 'Aceitamos cartões de crédito e débito das principais bandeiras, além de pagamento em dinheiro e PIX. Infelizmente, não aceitamos cheques.'
}, {
  label: 'O que devo fazer se precisar cancelar minha reserva?',
  content: 'Se você precisar cancelar sua reserva, entre em contato conosco o mais rápido possível. Cancelamentos com menos de 24 horas de antecedência podem estar sujeitos a uma taxa.'
}]
</script>

<template>
  <div class="m-20">
    <ULandingFAQ :items="items" multiple />
  </div>
</template>
