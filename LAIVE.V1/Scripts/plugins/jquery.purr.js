(function ($) {

   $.purr = function (notice, options) {
      // Convert notice to a jQuery object
      notice = $(notice);

      // Add a class to denote the notice as not sticky
      if (!options.isSticky) {
         notice.addClass('not-sticky');
      };

      // Get the container element from the page
      var cont = document.getElementById('purr-container');

      // If the container doesn't yet exist, we need to create it
      if (!cont) {
         cont = '<div id="purr-container"></div>';
      }

      // Convert cont to a jQuery object
      cont = $(cont);

      // Add the container to the page
      $('body').append(cont);

      notify();

      function notify() {
         // Set up the close button
         var close = document.createElement('a');
         close.innerHTML = '<i class="el-cancel"></i>';
         $(close).attr(
         {
            class: 'noticeClose',
            href: '#close'
         }
      )
         .appendTo(notice)
            .click(function () {
               removeNotice();

               return false;
            }
            );

         // Add the notice to the page and keep it hidden initially
         notice.appendTo(cont)
         .hide();

         if (navigator.userAgent.match(/msie/i) && options.usingTransparentPNG) {
            // IE7 and earlier can't handle the combination of opacity and transparent pngs, so if we're using transparent pngs in our
            // notice style, we'll just skip the fading in.
            notice.show();
         }
         else {
            //Fade in the notice we just added
            notice.fadeIn(options.fadeInSpeed);
         }

         // Set up the removal interval for the added notice if that notice is not a sticky
         if (!options.isSticky) {
            var topSpotInt = setInterval(function () {
               // Check to see if our notice is the first non-sticky notice in the list
               if (notice.prevAll('.not-sticky').length == 0) {
                  // Stop checking once the condition is met
                  clearInterval(topSpotInt);

                  // Call the close action after the timeout set in options
                  setTimeout(function () {
                     removeNotice();
                  }, options.removeTimer
            );
               }
            }, 3000);
         }
      }

      function removeNotice() {
         // IE7 and earlier can't handle the combination of opacity and transparent pngs, so if we're using transparent pngs in our
         // notice style, we'll just skip the fading out.
         if (navigator.userAgent.match(/msie/i) && options.usingTransparentPNG) {
            notice.css({ opacity: 0 })
           .animate(
              {
                 height: '0px'
              },
              {
                 duration: options.fadeOutSpeed,
                 complete: function () {
                    notice.remove();
                 }
              }
           );
         }
         else {
            // Fade the object out before reducing its height to produce the sliding effect
            notice.animate(
           {
              opacity: '0'
           },
           {
              duration: options.fadeOutSpeed,
              complete: function () {
                 notice.animate(
                     {
                        height: '0px'
                     },
                     {
                        duration: options.fadeOutSpeed,
                        complete: function () {
                           notice.remove();
                        }
                     }
                  );
              }
           }
        );
         }
      };
   };

   $.fn.purr = function (options) {
      options = options || {};
      options.fadeInSpeed = options.fadeInSpeed || 500;
      options.fadeOutSpeed = options.fadeOutSpeed || 500;
      options.removeTimer = options.removeTimer || 8000;
      options.isSticky = options.isSticky || false;
      options.usingTransparentPNG = options.usingTransparentPNG || false;

      this.each(function () {
         new $.purr(this, options);
      }
    );

      return this;
   };
})(jQuery);

