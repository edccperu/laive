/*!  VARIABLES GLOBALES */
var _VARIDCOLUM = "";
var _VARDSCOLUM = "";
var _VARIDFILTER = 0;

/* Progresse Bar */
(function ($) {
   // Simple wrapper around jQuery animate to simplify animating progress from your app
   // Inputs: Progress as a percent, Callback
   ; $.fn.animateProgress = function (progress, callback, valuebar) {
      return this.each(function () {
         $(this).animate({
            width: progress + '%'
         }, {
            duration: 1000,

            // swing or linear
            easing: 'swing',

            // this gets called every step of the animation, and updates the label
            step: function (progress) {
               var valueEl = $(valuebar);
               valueEl.text(Math.ceil(progress) + '%');

            },
            complete: function (scope, i, elem) {
               if (callback) {
                  callback.call(this, i, elem);
               };
            }
         });
      });
   };
})(jQuery);


/*MUESTR*/
function showTitleSystem(mensaje) {
   document.getElementById("samTituloSystema").innerHTML = mensaje;
   /*$("#samTituloSystema").show("drop", { distance: 50 }, 1000, null);*/
   $("#samTituloSystema").show("drop", { distance: 15 }, 1200, null);
}

/*! Devuelve tamanio para ajuste de la grilla*/
function getHeightForGrid(ajuste) {
   var _heightgrid = 0;
   var idcontrol = $("#idHeader").outerHeight();
   if (idcontrol)
      _heightgrid = _heightgrid + idcontrol;
   idcontrol = $("#idMenu").outerHeight();
   if (idcontrol)
      _heightgrid = _heightgrid + idcontrol;
   idcontrol = $("#idSearch").outerHeight();
   if (idcontrol)
      _heightgrid = _heightgrid + idcontrol;
   idcontrol = $("#EditPanelMaster").outerHeight();
   if (idcontrol)
      _heightgrid = _heightgrid + idcontrol + 40;

   _heightgrid = $(window).height() - _heightgrid - ajuste;

   return _heightgrid;
}

/*!  OPEN FILTER*/
function openFilter(dsColumn, idColumn) {
   _VARIDCOLUM = idColumn;
   _VARDSCOLUM = dsColumn;

   document.getElementById("inputbuscador").value = "";
   $("#popupFilter").dialog({ title: dsColumn });
   $('#popupFilter').dialog('open');

}

/*!  ADD FILTER*/
function addFilter() {
   var ftext = document.getElementById("inputbuscador").value;
   var fcbvalue = document.getElementById("selectbuscador");

   if (ftext == '') {
      MsgAlert(2,'Ingrese la busqueda.');
   }
   else {
      $("#idTextFilterControl").tokenInput("add", {
         id: _VARIDFILTER,
         foperator: false,
         fvalue: ftext,
         fcampo: _VARIDCOLUM,
         fconector: fcbvalue.value,
         fname: '  [' + _VARDSCOLUM + ']' + '  ' + fcbvalue.options[fcbvalue.selectedIndex].text + '  [' + ftext + ']'
      });

      $('#popupFilter').dialog('close');

      _VARIDFILTER++;
   }

}


/*!  ADD FILTER Laive*/
function addFilterLaive() {
   var ftext = document.getElementById("searchValueLaive").value;
   var fcbvalue = document.getElementById("searchColumnLaive");
   var fcboperator = document.getElementById("searchOperadorLaive");

   if (ftext == '') {
      MsgAlert(2,'Ingrese la busqueda.');
   }
   else {
      $("#idTextFilterControl").tokenInput("add", {
         id: _VARIDFILTER,
         foperator: false,
         fvalue: ftext,
         fcampo: fcbvalue.value,
         fconector: fcboperator.value,
         fname: '  [' + fcbvalue.options[fcbvalue.selectedIndex].text + ']' + '  ' + fcboperator.options[fcboperator.selectedIndex].text + '  [' + ftext + ']'
      });
      _VARIDFILTER++;

      var vartoken = $("#idTextFilterControl").tokenInput("get");

      $('#GridBandeja').flexOptions({ query: JSON.stringify(vartoken) }).flexReload();

      document.getElementById("searchValueLaive").value = '';

   }

}

/*!  clear FILTER*/
function clearFilter() {
   $("#idTextFilterControl").tokenInput("clear");
   $('#GridBandeja').flexOptions({ query: '' }).flexReload();
   _VARIDFILTER = 0;
}

/*!  search FILTER*/
function searchFilter() {

   var vartoken = $("#idTextFilterControl").tokenInput("get");

   $.ajax({
      beforeSend: function () {
         $("#samLoading").show("fade", 300);
      },
      complete: function () {
         $("#samLoading").hide("fade", 300);
      },
      type: "POST",
      contentType: "application/json; charset=utf-8",
      url: "/TablaGeneral/GetBandeja/",
      data: JSON.stringify(vartoken),
      dataType: "html",
      success: function (result) {
         if (result.indexOf('idPopupLogin') != -1)
            window.location.href = "/Login";
         else
            $('#samnetgrid').flexAddData(JSON.parse(result));
      },
      error: function (xhr, status, error) {
         alert(error.toString());
      }
   });

}

function AppAjax(varType,varTypeResult,varUrl, datalink, idcontrolcontent, showLoad, hideLoad, functionParam) {

   $.ajax({
      beforeSend: function () {
         if (showLoad == true)
            $("#samLoading").show("fade", 300);
      },
      complete: function () {
         if (hideLoad == true)
            $("#samLoading").hide("fade", 300);
      },
      type: varType,
      url: varUrl,
      data: datalink,
      dataType: varTypeResult,
      success: function (result) {
         if (typeof result != "object" && result.indexOf('idPopupLogin') != -1)
            window.location.href = "/Login";
         else {
            if (idcontrolcontent != null && idcontrolcontent != "")
               $("#" + idcontrolcontent).html(result);
         }

         if (typeof functionParam == 'function')
            functionParam(result);
      },
      error: function (xhr, status, error) {
         if (error.toString() == "")
            error = xhr.statusText;
         MsgAlert(3, error.toString());
      }
   });

}

function AppAjaxString(varType, varTypeResult, varUrl, datalink, idcontrolcontent, showLoad, hideLoad, functionParam) {

   $.ajax({
      beforeSend: function () {
         if (showLoad == true)
            $("#samLoading").show("fade", 300);
      },
      complete: function () {
         if (hideLoad == true)
            $("#samLoading").hide("fade", 300);
      },
      type: varType,
      contentType: "application/json; charset=utf-8",
      url: varUrl,
      data: JSON.stringify(datalink),
      dataType: varTypeResult,
      success: function (result) {
         if (typeof result != "object" && result.indexOf('idPopupLogin') != -1)
            window.location.href = "/Login";
         else {
            if (idcontrolcontent != null && idcontrolcontent != "")
               $("#" + idcontrolcontent).html(result);
         }

         if (typeof functionParam == 'function')
            functionParam(result);
      },
      error: function (xhr, status, error) {
         if (error.toString() == "")
            error = xhr.statusText;
         MsgAlert(3, error.toString());
      }
   });

}


/*-LINK AJAX PARA SAM NET DATA FOR DEFAULT*/
function samlinkajaxData(varUrl, datalink, idcontrolcontent, showLoad, hideLoad) {
   $.ajax({
      beforeSend: function () {
         if (showLoad == true)
            $("#samLoading").show("fade", 300);
      },
      complete: function () {
         if (hideLoad == true)
            $("#samLoading").hide("fade", 300);
      },
      type: "GET",
      contentType: "application/json; charset=utf-8",
      url: varUrl,
      data: datalink,
      dataType: "html",
      success: function (result) {
         if (result.indexOf('idPopupLogin') != -1)
            window.location.href = "/Login";
         else {
            if (idcontrolcontent != "")
               $("#" + idcontrolcontent).html(result);
         }

      },
      error: function (xhr, status, error) {
         if (error.toString() == "")
            error = xhr.statusText;
         MsgAlert(3,error.toString());
      }
   });

}

function samlinkajaxDataFunction(varUrl, datalink, idcontrolcontent, showLoad, hideLoad, functionParam) {
   $.ajax({
      beforeSend: function () {
         if (showLoad == true)
            $("#samLoading").show("fade", 300);
      },
      complete: function () {
         if (hideLoad == true)
            $("#samLoading").hide("fade", 300);
      },
      type: "GET",
      contentType: "application/json; charset=utf-8",
      url: varUrl,
      data: datalink,
      dataType: "html",
      success: function (result) {
         if (result.indexOf('idPopupLogin') != -1)
            window.location.href = "/Login";
         else {
            if (idcontrolcontent != "")
               $("#" + idcontrolcontent).html(result);
         }

         if (typeof functionParam == 'function')
            functionParam(result);
      },
      error: function (xhr, status, error) {
         if (error.toString() == "")
            error = xhr.statusText;
         MsgAlert(3,error.toString());
      }
   });

}

function samlinkajaxDataFunctionParseJson(varUrl, datalink, idcontrolcontent, showLoad, hideLoad, functionParam) {
   $.ajax({
      beforeSend: function () {
         if (showLoad == true)
            $("#samLoading").show("fade", 300);
      },
      complete: function () {
         if (hideLoad == true)
            $("#samLoading").hide("fade", 300);
      },
      type: "POST",
      contentType: "application/json; charset=utf-8",
      url: varUrl,
      data: JSON.stringify(datalink),
      dataType: "html",
      success: function (result) {
         if (result.indexOf('idPopupLogin') != -1)
            window.location.href = "/Login";
         else {
            if (idcontrolcontent != "")
               $("#" + idcontrolcontent).html(result);
         }

         if (typeof functionParam == 'function')
            functionParam();
      },
      error: function (xhr, status, error) {
         if (error.toString() == "")
            error = xhr.statusText;
         MsgAlert(3,error.toString());
      }
   });

}

/*-LINK AJAX PARA SAM NET DATA CONVER JSON*/
function samlinkajax(varUrl, datalink, idcontrolcontent, showLoad, hideLoad) {
   $.ajax({
      beforeSend: function () {
         if (showLoad == true)
            $("#samLoading").show("fade", 300);
      },
      complete: function () {
         if (hideLoad == true)
            $("#samLoading").hide("fade", 300);
      },
      type: "GET",
      cache: false,
      contentType: "application/json; charset=utf-8",
      url: varUrl,
      data: JSON.stringify(datalink),
      dataType: "html",
      success: function (result) {
         if (result.indexOf('idPopupLogin') != -1)
            window.location.href = "/Login";
         else {

            $("#" + idcontrolcontent).html(result);
         }
      },
      error: function (xhr, status, error) {
         if (error.toString() == "")
            error = xhr.statusText;
         MsgAlert(3,error.toString());
      }
   });

}


/*-LINK AJAX GUARDAR DATOS SAM NET*/
function samlinkajaxUpdateModel(varUrl, datalink, idNewCode, showLoad, hideLoad) {
   $.ajax({
      beforeSend: function () {
         if (showLoad == true)
            $("#samLoading").show("fade", 300);
      },
      complete: function () {
         if (hideLoad == true)
            $("#samLoading").hide("fade", 300);
      },
      type: "POST",
      contentType: "application/json; charset=utf-8",
      url: varUrl,
      data: JSON.stringify(datalink),
      dataType: "html",
      success: function (result) {
         if (result.indexOf('idPopupLogin') != -1)
            window.location.href = "/Login";
         else {
            var arrComp = result.split(';');
            if ((typeof arrComp[1] != 'undefined') && (arrComp[1] != '')) {
               switch (arrComp[0]) {
                  case "1":
                     MsgAlert(1,arrComp[1]);
                     break;
                  case "2":
                     MsgAlert(2,arrComp[1]);
                     break;
                  case "3":
                     MsgAlert(3,arrComp[1]);
                     break;
               }
               if (idNewCode != null && (document.getElementById(idNewCode).value == "" || document.getElementById(idNewCode).value == "0")) {
                  document.getElementById(idNewCode).value = arrComp[2];
                  document.getElementById("EntityState").value = SamGetStateModified();
               }
            }
         }


      },
      error: function (xhr, status, error) {
         MsgAlert(3,error.toString());
      }
   });
}

function ajaxForUpdateGrid(varUrl, datalink, grid) {
   $.ajax({
      type: "GET",
      url: varUrl,
      data: datalink,
      dataType: "html",
      success: function (result) {
         if (result.indexOf('idPopupLogin') != -1)
            window.location.href = "/Login";
         else
            $('#' + grid).flexReload();

      },
      error: function (xhr, status, error) {
         MsgAlert(3,error.toString());
      }
   });

}

/* ALERT TYPE */
function MsgAlert(type, message) {
   var objectAlert;
   switch (type) {
      case 1:
         objectAlert = '<div class="notice verde"><div class="notice-body-verde">'
                                    + '<i class="el-ok-circled"></i>'
                                    + '<div class="noticeText">' + message + '<div>'
                    + '</div></div>';
         break;
      case 2:
         objectAlert = '<div class="notice naranja"><div class="notice-body-naranja">'
                                    + '<i class="fa fa-warning"></i>'
                                    + '<div class="noticeText">' + message + '<div>'
                    + '</div></div>';
         break;
      case 3:
         objectAlert = '<div class="notice rojo"><div class="notice-body-rojo">'
                                    + '<i class="el-cancel-circled"></i>'
                                    + '<div class="noticeText">' + message + '<div>'
                    + '</div></div>';

         break;
   }
   $(objectAlert).purr({ usingTransparentPNG: true });
}

/*CLEAR CONTROL*/
function SamClearControl(control, isReadOnly) {

   var objDOM = document.getElementById(control);

   switch (objDOM.type) {
      case "text":
      case "textarea":
         objDOM.value = "";
         break;
      case "checkbox":
         objDOM.checked = false;
         break;
      default:
         objDOM.value = "";
         break;
   }

   document.getElementById(control).disabled = isReadOnly;
   $('#' + control).removeClass("text-box-error");
   $('#' + control).smallipop('destroy');
}

/*SET INPUT VALUE*/
function SamSetInputValue(control, item, index, isReadOnly) {
   var objDOM = document.getElementById(control);

   switch (objDOM.type) {
      case "checkbox":

         if ((item.cells[index].innerText || item.cells[index].textContent) == "true" || (item.cells[index].innerText || item.cells[index].textContent) == "1" || (item.cells[index].innerText || item.cells[index].textContent) == "True")
            objDOM.checked = true;
         else
            objDOM.checked = false;
         break;
      case "text":
      case "textarea":
         objDOM.value = item.cells[index].innerText || item.cells[index].textContent;
         break;
      default:
         objDOM.value = item.cells[index].innerText || item.cells[index].textContent;
         break;
   }

   objDOM.disabled = isReadOnly;
}

/* SET ENTITY STATE*/
function SamStateAdded(control) {
   document.getElementById(control).value = 0;
}
function SamStateModified(control) {
   document.getElementById(control).value = 1;
}
function SamStateDeleted(control) {
   document.getElementById(control).value = 2;
}
function SamStateUnchanged(control) {
   document.getElementById(control).value = 3;
}
/* GET ENTITY STATE*/
function SamGetStateAdded() {
   return 0;
}
function SamGetStateModified() {
   return 1;
}
function SamGetStateDeleted() {
   return 2;
}
function SamGetStateUnchanged() {
   return 3;
}

/* VALIDATE EMPY CONTROL*/
function SamControlEsValido(control, Mensaje) {
   if (document.getElementById(control).value == "") {
      $('#' + control).addClass("text-box-error");
      $('#' + control).smallipop({
         preferredPosition: 'right',
         popupDistance: 0,
         popupOffset: 10,
         theme: 'orange'
      }, Mensaje);
      return false;
   }
   else {
      $('#' + control).removeClass("text-box-error");
      $('#' + control).smallipop('destroy');
      return true;
   }
}

/* SET ERROR OR SUCCESS OBJECT*/
function SetErroControl(control, Mensaje, haveError) {
   if (haveError == true) {
      $('#' + control).addClass("text-box-error");
      $('#' + control).smallipop({
         preferredPosition: 'right',
         popupDistance: 0,
         popupOffset: 10,
         theme: 'orange'
      }, Mensaje);
      return false;
   }
   else {
      $('#' + control).removeClass("text-box-error");
      $('#' + control).smallipop('destroy');
      return true;
   }
}

/* Iniciar Progress Bar*/
function InitProgressBar(idBarraEstado) {
   var myNumero = Math.floor(Math.random() * (50 - 20)) + 20
   $('#' + idBarraEstado + ' .sam-ui-progress').animateProgress(myNumero, null, '#' + idBarraEstado + 'Value');
   $('#' + idBarraEstado + 'Img').show();
   $('#' + idBarraEstado + 'Img').attr("src", "../../Content/animation/Import.GIF");
   $("#" + idBarraEstado + 'Value').html("0%");
}

function FinishProgressBar(idBarraEstado, isValid) {
   $('#' + idBarraEstado + 'Img').show();
   $('#' + idBarraEstado + ' .sam-ui-progress').animateProgress(100, null, '#' + idBarraEstado + 'Value');
   if (isValid)
      $('#' + idBarraEstado + 'Img').attr("src", "../../Content/images/correctImport.png");
   else
      $('#' + idBarraEstado + 'Img').attr("src", "../../Content/images/ErrorImport.png");
}


function CreateTab(idTab, idDiv) {
   $("#" + idDiv + " .tab_content").hide();
   $("#" + idDiv + " .tab_content:first").show();

   $("#" + idTab + " li").click(function () {
      $("#" + idTab + " li").removeClass("active");
      $(this).addClass("active");
      $("#" + idDiv + " .tab_content").hide();
      var activeTab = $(this).attr("rel");
      $("#" + activeTab).fadeIn();
   });

}

/* --------------VERIFICAR SI LA PAGINA SE ESTA DIRECCIONANDO A LOGIN------------------*/
function IsLoginRedirect(result) {
    
   if (typeof result != "object" && result.indexOf('idPopupLogin') != -1)
      return true;
   else
      return false;
}

function ExportToExcel(header, idTable) {

   var excel = '<table>';

   excel += '<thead><tr>';

   header.forEach(function (item) {
      if ((typeof item.exportXls == "undefined" || item.exportXls == true) && (typeof item.hide == "undefined" || item.hide == false))
         excel += '<th>' + item.display + '</th>';
   });

   excel += '</tr></thead>';
   var content = '';

   $('#' + idTable).find('tbody').find('tr').each(function () {
      content += "<tr>";
      $(this).find('td').each(function (index, data) {
         if (idTable == "grdPeConso" && (index == 3 || index == 7))
            return;
         if (data.style.display != "none")
            if (!$(data.childNodes[0]).is(':checkbox'))
               if (index == 3 || index == 4 || index == 5)
                  content += "<td>" + data.childNodes[0].innerText || data.childNodes[0].innerHTML + "</td>";
               else
                  content += "<td><span>" + data.childNodes[0].innerText || data.childNodes[0].innerHTML + "</span></td>";
            else
               content += "<td></td>";
      });
      content += '</tr>';
   });

   if (content == '') {
      MsgAlert(2,"No se encontraron Datos para exportar.");
      return false;
   }

   excel = excel + content + '</table>'

   var excelFile = "<html xmlns:o='urn:schemas-microsoft-com:office:office' xmlns:x='urn:schemas-microsoft-com:office:excel' xmlns='http://www.w3.org/TR/REC-html40'>";
   excelFile += "<head>";
   excelFile += "<!--[if gte mso 9]>";
   excelFile += "<xml>";
   excelFile += "<x:ExcelWorkbook>";
   excelFile += "<x:ExcelWorksheets>";
   excelFile += "<x:ExcelWorksheet>";
   excelFile += "<x:Name>";
   excelFile += "{worksheet}";
   excelFile += "</x:Name>";
   excelFile += "<x:WorksheetOptions>";
   excelFile += "<x:DisplayGridlines/>";
   excelFile += "</x:WorksheetOptions>";
   excelFile += "</x:ExcelWorksheet>";
   excelFile += "</x:ExcelWorksheets>";
   excelFile += "</x:ExcelWorkbook>";
   excelFile += "</xml>";
   excelFile += "<![endif]-->";
   excelFile += "</head>";
   excelFile += "<body>";
   excelFile += excel;
   excelFile += "</body>";
   excelFile += "</html>";

   var base64data = "base64," + $.base64.encode(excelFile);
   window.open('data:application/vnd.ms-excel;filename=exportData.xlsx;' + base64data);
}

function stringToDecimal(string) {
   return parseFloat(string.toString().trim().replace(/,/g, ""));
}

function stringToInt(string) {
   return parseInt(string.toString().trim().replace(/,/g, ""));
}

/*FUNCION PARA SETEAR DATOS DE LOS COMBOS CON DATOS DE LAS GRILLAS*/
function SetComboBoxFromGrid(grid, combo, iValue, iText) {
   var rows = $('#' + grid).jqGrid('getGridParam', 'data');
   SetDataComboBox(combo, rows, iValue, iText, '')
}

function SetDataComboBox(idcontrol, vardata, varvalue, vartext, firstelemnt) {

   if (typeof vardata === 'undefined' || vardata == null) {
      $("#" + idcontrol).empty();
      return;
   }

   var select = $('#' + idcontrol);

   $('option', select).remove();

   if (firstelemnt != null) {
      var option = new Option(firstelemnt, '');
      select.append($(option));
   }

   $.each(vardata, function (i, item) {
      option = new Option(item[vartext], item[varvalue]);
      select.append($(option));
   });
}

function BloquearComboBox(id) {
   $('#' + id).addClass("loadComboBox");
   document.getElementById(id).disabled = true;
}

function DesbloquearComboBox(id) {
   $('#' + id).removeClass("loadComboBox");
   document.getElementById(id).disabled = false;
}
