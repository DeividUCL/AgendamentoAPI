<script setup lang="ts">
definePageMeta({
  layout: 'exibir-agenda',
})
import 'v-calendar/dist/style.css'

const props = defineProps({
  modelValue: {
    type: Date,
    default: null
  }
})

const emit = defineEmits(['update:model-value', 'close'])

const colorMode = useColorMode()

const isDark = computed(() => colorMode.value === 'dark')

const date = computed({
  get: () => props.modelValue,
  set: (value) => {
    emit('update:model-value', value)
    emit('close')
  }
})

const attrs = [{
  key: 'today',
  highlight: {
    color: 'green',
    fillMode: 'outline',
    class: '!bg-gray-100 dark:!bg-gray-800'
  },
  dates: new Date()
}]
</script>

<template>
  <div class="flex justify-start m-10">
    <VCalendar expanded view="weekly" :min-date="new Date()" v-model="date" transparent borderless :attributes="attrs"
      :is-dark="isDark" title-position="right" trim-weeks :first-day-of-week="1" />
  </div>
</template>
