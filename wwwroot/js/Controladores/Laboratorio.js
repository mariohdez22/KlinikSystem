
const botonDetalle = document.querySelectorAll('.botonAgregarPrueba');

var num = 0

let val = 0

let subtotal = 0;

let AgregarDetalleExamen = (id) =>
{
    let tarjetaDetalle = document.querySelector(`input[value="${id}"]`).closest('#tarjetaRegistroPrueba2');
    let codigoDetalle = 'PTYU8723'
    let idPruebaExamen = tarjetaDetalle.querySelector('.inputPruebaExamen').value;
    let nombrePrueba = tarjetaDetalle.querySelector('.inputNombrePrueba').value;
    let precio = tarjetaDetalle.querySelector('.inputPrecioPrueba').value;

    let ContenedorTarjetasDetalle = document.getElementById("cuerpoPruebaExamen");

    ContenedorTarjetasDetalle.innerHTML +=
    `
        <div id="tarjetaRegistroPrueba">

            <div id="contenedorDatos">

                <div id="datoRegistrosDatos">

                    <div id="iconoRegistroDatos"><i class="bi bi-7-circle-fill"></i></div>

                    <div id="atributoRegistroDatos">
                        <p>${codigoDetalle}</p>
                    </div>

                </div>

                <div id="datoRegistrosDatos">

                    <div id="iconoRegistroDatos"><i class="bi bi-p-circle-fill"></i></div>

                    <div id="atributoRegistroDatos">
                        <p>${nombrePrueba}</p>
                    </div>

                </div>                        

            </div>

            <div id="tarjetaDatosExamen">          
                
            </div>

            <div id="contenedorSubtotal">

                <div id="datoAcumulador">

                    <div id="iconoAcumulador"><i class="bi bi-currency-dollar"></i></div>

                    <div id="atributoAcumulador">
                        <p>15.00</p>
                    </div>

                </div>

            </div>

            <input name="DetalleExamen.Index" type="hidden" value="${num}">
            <input name="DetalleExamen[${num}].CodigoDetalle" type="hidden" value="${codigoDetalle}">
            <input name="DetalleExamen[${num}].IdpruebaExamen" type="hidden" value="${idPruebaExamen}">
            <input name="DetalleExamen[${num}].Subtotal" type="hidden" value="${precio}">

        </div>
    `

    num++;

}

botonDetalle.forEach((boton) => {
    boton.addEventListener('click', function (e) {
        e.preventDefault();
        let id = this.getAttribute('data-id');
        AgregarDetalleExamen(id);
    });
});

//-------------------------------------------------------------------------------------------

let numberDatos = 0;

let AgregarDatosExamen = (elementoActual) =>
{
    let tarjetaDatos = elementoActual.parentElement.parentElement;
    let idDato = tarjetaDatos.querySelector('.inputDatoExamen').value;
    let Nombre = tarjetaDatos.querySelector('.inputNombreDato').value;
    let Precio = tarjetaDatos.querySelector('.inputPrecioDato').value;

    let ContenedorTarjetasDatos = document.getElementById(`tarjetaDatosExamen`);

    ContenedorTarjetasDatos.innerHTML +=
    `
        <div id="contenedorDatosExamen">

            <div id="datoRegistrosDatosExamen">

                <div id="iconoRegistroDatosExamen"><i class="bi bi-bookmark-plus-fill"></i></div>

                <div id="atributoRegistroDatosExamen">
                    <p>${Nombre}</p>
                </div>

            </div>

            <div id="datoRegistrosDatosExamen">

                <div id="iconoRegistroDatosExamen"><i class="bi bi-coin"></i></div>

                <div id="atributoRegistroDatosExamen">
                    <p>${Precio}</p>
                </div>

            </div>

            <input name="DetalleExamen[${num}].DetalleDatos[${numberDatos}].IddatoExamen" type="hidden" value="${idDato}">
            <input name="DetalleExamen[${num}].DetalleDatos[${numberDatos}].Precio" type="hidden" value="${Precio}">

        </div>
    `

    numberDatos++;
}