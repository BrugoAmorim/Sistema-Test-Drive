
const body = document.getElementById('container-master');

// Selecione todos os links com hash
jQuery('a[href*="#"]')
  .not('[href="#"]')
  .not('[href="#0"]')
  .click(function(event) {
    if (
      location.pathname.replace(/^\//, '') == this.pathname.replace(/^\//, '') 
      && 
      location.hostname == this.hostname
    ) {
      let target = jQuery(this.hash);
      target = target.length ? target : jQuery('[name=' + this.hash.slice(1) + ']');
      // Se o elemento de destino existir
      if (target.length) {
        // Animação de rolagem suave
        jQuery('html, body').animate({
          scrollTop: target.offset().top
        }, 800);
        event.preventDefault();
      }
    }
  });