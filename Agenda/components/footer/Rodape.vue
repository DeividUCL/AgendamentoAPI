<template>
  <div class="footer">
    <div class="grid bg-primary-reverse">
      <div class="col ml-8">
        <div class="text-5xl">
          <FooterLogo />
        </div>
        <p>© 2024 Circuito Pitanga, todos os direitos reservados.</p>
      </div>
      <div class="col">
        <ul class="list-none flex justify-content-end mr-8 gap-8">
          <li><a class="text-7xl pi pi-facebook no-underline" href="https://www.facebook.com/seuusuario" /></li>
          <li><a class="text-7xl pi pi-instagram no-underline" href="https://www.instagram.com/seuusuario" /></li>
        </ul>
      </div>
    </div>
  </div>
</template>

<style scoped>
.footer {
  position: fixed;
  bottom: 0;
  width: 100%;
}
</style>
