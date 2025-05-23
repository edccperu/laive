/*!
 * jQuery UI Widget-factory plugin boilerplate (for 1.8/9+)
 * Author: @addyosmani
 * Further changes: @peolanha
 * Licensed under the MIT license
 */

; (function ($, window, document, undefined) {

   // define your widget under a namespace of your choice
   //  with additional parameters e.g.
   // $.widget( "namespace.widgetname", (optional) - an
   // existing widget prototype to inherit from, an object
   // literal to become the widget's prototype );

   $.widget("grantorino.timeline", {

      //Options to be used as defaults
      options: {
         someValue: null
      },

      _tpl_event: ['<li class="tl-item">',
						'<div class="tl-wrap {{class}}">',
							'<span class="tl-date">{{time}}</span>',
							'<div class="tl-content panel padder b-a" {{color}}>',
								'<span class="arrow left pull-up" {{colorRow}}></span>',
								'<div>{{content}}</div>',
							'</div>',
						'</div>',
					'</li>'
      ].join('\n'),

      //Setup widget (eg. element creation, apply theming
      // , bind events etc.)
      _create: function () {

         // _create will automatically run the first time
         // this widget is called. Put the initial widget
         // setup code here, then you can access the element
         // on which the widget was called via this.element.
         // The options defined above can be accessed
         // via this.options this.element.addStuff();
         // 
         // 
         this._buildContainer();
         this._buildTimeline();
      },

      // Destroy an instantiated plugin and clean up
      // modifications the widget has made to the DOM
      destroy: function () {

         // this.element.removeStuff();
         // For UI 1.8, destroy must be invoked from the
         // base widget
         $.Widget.prototype.destroy.call(this);
         // For UI 1.9, define _destroy instead and don't
         // worry about
         // calling the base widget
      },

      add: function (event_data) {
         //_trigger dispatches callbacks the plugin user
         // can subscribe to
         // signature: _trigger( "callbackName" , [eventObject],
         // [uiObject] )
         // eg. this._trigger( "hover", e /*where e.type ==
         // "mouseenter"*/, { hovered: $(e.target)});
         // 

         if ($.isArray(event_data)) {
            var that = this;
            $.each(event_data, function (index, tl_event) {
               that.add(tl_event);
            });
         } else {

            this.element.find("ul.timeline").append(
							this._render_event(event_data)
						);
         }

      },

      methodA: function (event) {
         this._trigger("dataChanged", event, {
            key: "someValue"
         });
      },

      setData: function (event_data) {
         //_trigger dispatches callbacks the plugin user
         // can subscribe to
         // signature: _trigger( "callbackName" , [eventObject],
         // [uiObject] )
         // eg. this._trigger( "hover", e /*where e.type ==
         // "mouseenter"*/, { hovered: $(e.target)});
         // 

         this.element.find("ul.timeline").empty();

         if (event_data.length == 0) {
            var _html = '';
            _html += '<div style="border: 1px solid #D3D3D3;height: 100%; width: 100%;font-size: 12px;text-align: center;position: relative;">';
            _html += '<div style="top:50%;position: relative;">';
            _html += '<img src="../../Content/images/gridAlert.png"/><br/>No se encontraron registros.</div>';
            this.element.find("ul.timeline").append(_html);
         } else {

            if ($.isArray(event_data)) {
               var that = this;
               $.each(event_data, function (index, tl_event) {
                  that.element.find("ul.timeline").append(
                       that._render_event(tl_event)
                    );
               });
            } else {

               this.element.find("ul.timeline").append(
                        this._render_event(event_data)
                     );
            }
         }
      },


      _render_event: function (data) {
         var event_html = "";
         event_html = this._tpl_event.replace('{{time}}', data.time);
         event_html = event_html.replace('{{content}}', data.content);

         if (typeof data.css === "undefined" || data.css == null)
            event_html = event_html.replace('{{class}}', "");
         else
            event_html = event_html.replace('{{class}}', data.css);

         if (typeof data.color === "undefined" || data.color == null) {
            event_html = event_html.replace('{{color}}', '');
            event_html = event_html.replace('{{colorRow}}', '');
         }
         else {
            event_html = event_html.replace('{{color}}', 'style="border-color: ' + data.color + ';"');
            event_html = event_html.replace('{{colorRow}}', 'style="border-right-color: ' + data.color + ';"');
         }

         return event_html;

      },

      _buildTimeline: function () {

         var that = this;

         if (this.options.data.length == 0) {
            var _html = '';
            _html += '<div style="border: 1px solid #D3D3D3;height: 100%; width: 100%;font-size: 12px;text-align: center;position: relative;">';
            _html += '<div style="top:50%;position: relative;">';
            _html += '<img src="../../Content/images/gridAlert.png"/><br/>No se encontraron registros.</div></div>';
            that.element.find("ul.timeline").append(_html);
         }
         else {

            $.each(this.options.data, function (index, tl_event) {
               that.element.find("ul.timeline").append(that._render_event(tl_event));
            });
         }


      },

      _buildContainer: function () {
         this.element.append('<ul class="timeline"></ul>');
      },

      // Respond to any changes the user makes to the
      // option method
      _setOption: function (key, value) {
         switch (key) {
            case "someValue":
               //this.options.someValue = doSomethingWith( value );
               break;
            default:
               //this.options[ key ] = value;
               break;
         }

         // For UI 1.8, _setOption must be manually invoked
         // from the base widget
         $.Widget.prototype._setOption.apply(this, arguments);
         // For UI 1.9 the _super method can be used instead
         // this._super( "_setOption", key, value );
      }
   });

})(jQuery, window, document);



