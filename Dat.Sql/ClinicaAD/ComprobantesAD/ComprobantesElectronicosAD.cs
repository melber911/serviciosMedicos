using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Data.SqlClient;
using Ent.Sql.ClinicaE.ComprobantesE;
using Entidades.ClinicaE.ComprobantesE;
using System.Data;

namespace Dat.Sql.ClinicaAD.ComprobantesAD
{
    public class ComprobantesElectronicosAD
    {
        private ComprobantesElectronicosE LlenarEntidad(IDataReader dr, ComprobantesElectronicosE pComprobantesElectronicosE)
        {
            ComprobantesElectronicosE oComprobantesElectronicosE = new ComprobantesElectronicosE();
            switch (pComprobantesElectronicosE.Orden)
            {
                case 1:
                    {
                        oComprobantesElectronicosE.Codcomprobante = (string)dr["codcomprobante"];
                        oComprobantesElectronicosE.Codempresa = (string) dr["codempresa"];
                        oComprobantesElectronicosE.Codsist = (string) dr["codsist"];
                        oComprobantesElectronicosE.TipocompSunat = (string) dr["tipocomp_sunat"];
                        oComprobantesElectronicosE.Codcomprobantee = (string) dr["codcomprobantee"];
                        oComprobantesElectronicosE.TipoOtorgamiento = (string) dr["tipo_otorgamiento"];
                        oComprobantesElectronicosE.EstadoCdr = (int) dr["estado_cdr"];
                        oComprobantesElectronicosE.FlgConfirma = (bool) dr["flg_confirma"];
                        oComprobantesElectronicosE.FlgOtorgamiento = (bool) dr["flg_otorgamiento"];
                        oComprobantesElectronicosE.FlgEnbaja = (string) dr["flg_enbaja"];
                        oComprobantesElectronicosE.FechaRegistroSis = (DateTime) dr["fecha_registro_sis"];
                        oComprobantesElectronicosE.FechaRegistroRpta = (DateTime) dr["fecha_registro_rpta"];
                        oComprobantesElectronicosE.XmlRegistro = (string) dr["xml_registro"];
                        oComprobantesElectronicosE.XmlRegistroRpta = (string) dr["xml_registro_rpta"];
                        oComprobantesElectronicosE.ObservacionRegistro = (string) dr["observacion_registro"];
                        oComprobantesElectronicosE.CodigoHash = (string) dr["codigohash"];
                        oComprobantesElectronicosE.CodigoBarra = (byte[]) dr["codigobarra"];
                        oComprobantesElectronicosE.FechaCdrSis = (DateTime) dr["fecha_cdr_sis"];
                        oComprobantesElectronicosE.FechaCdrSunat = (DateTime) dr["fecha_cdr_sunat"];
                        oComprobantesElectronicosE.ObservacionCdr = (string) dr["observacion_cdr"];
                        oComprobantesElectronicosE.FechaConfirmaSis = (DateTime) dr["fecha_confirma_sis"];
                        oComprobantesElectronicosE.ObservacionConfirma = (string) dr["observacion_confirma"];
                        oComprobantesElectronicosE.FechaOtorgamientoSis = (DateTime) dr["fecha_otorgamiento_sis"];
                        oComprobantesElectronicosE.FechaOtorgamiento = (DateTime) dr["fecha_otorgamiento"];
                        oComprobantesElectronicosE.ObservacionOtorgamiento = (string) dr["observacion_otorgamiento"];
                        oComprobantesElectronicosE.Correo = (string) dr["correo"];
                        oComprobantesElectronicosE.Tipoafectacionigv = (string) dr["tipoafectacionigv"];
                        oComprobantesElectronicosE.IdeTranssap = (Int32) dr["ide_transSAP"];
                        oComprobantesElectronicosE.FlgEnviosap = (bool) dr["flg_enviosap"];
                        oComprobantesElectronicosE.FecEnviosap = (DateTime) dr["fec_enviosap"];
                        oComprobantesElectronicosE.IdeDocentrysap = (string) dr["ide_docentrysap"];
                        oComprobantesElectronicosE.FecDocentrysap = (DateTime) dr["fec_docentrysap"];
                        oComprobantesElectronicosE.FlgEnviobajasap = (bool) dr["flg_enviobajasap"];
                        oComprobantesElectronicosE.FecEnviobajasap = (DateTime) dr["fec_enviobajasap"];
                        break;
                    }
            }
            return oComprobantesElectronicosE;
        }

        private ComprobanteElectronicoXMLCabE LlenarEntidadXMLCab(IDataReader dr, int pOrden = 1)
        {
            ComprobanteElectronicoXMLCabE oComprobantesElectronicosE = new ComprobanteElectronicoXMLCabE();

            switch (pOrden)
            {
                case 1:
                    {
                        oComprobantesElectronicosE.CodComprobante = (string) dr["codcomprobante"];
                        oComprobantesElectronicosE.CodComprobanteE = (string) dr["codcomprobante_e"];
                        oComprobantesElectronicosE.TipoPlantilla = (string) dr["tipoplantilla"];
                        oComprobantesElectronicosE.TipoCompSunat = (string) dr["tipocomp_sunat"];

                        oComprobantesElectronicosE.TipoCompTci = (string) (dr["tipocomp_tci"]);
                        oComprobantesElectronicosE.Estado = (string) dr["estado"];
                        oComprobantesElectronicosE.NombreEstado = (string) dr["nombreestado"];

                        oComprobantesElectronicosE.ParaQuien = (string) dr["paraquien"];
                        oComprobantesElectronicosE.CodLiquidacion = (string) dr["codliquidacion"];
                        oComprobantesElectronicosE.FechaEmision = (string) dr["fechaemision"];
                        oComprobantesElectronicosE.ANombreDe = (string) (dr["anombrede"] + "");
                        oComprobantesElectronicosE.Direccion = (string) dr["direccion"];
                        oComprobantesElectronicosE.Ruc = (string) dr["ruc"];
                        oComprobantesElectronicosE.TipDocIdentidadSunat = (string) dr["tipdocidentidad_sunat"] + "";
                        oComprobantesElectronicosE.RucSunat = (string) dr["ruc_sunat"];
                        oComprobantesElectronicosE.ReceptorCorreo = (string) dr["receptor_correo"];
                        oComprobantesElectronicosE.EmpresaRuc = (string) dr["empresa_ruc"];
                        oComprobantesElectronicosE.EmpresaTipoDocIdentidad = (string) dr["empresa_tipodocidentidad"];
                        oComprobantesElectronicosE.EmpresaNombre = (string) dr["empresa_nombre"];
                        oComprobantesElectronicosE.EmpresaDireccion = (string) dr["empresa_direccion"];
                        oComprobantesElectronicosE.EmpresaTelefono = (string) dr["empresa_telefono"];

                        oComprobantesElectronicosE.Concepto = (string) dr["concepto"];
                        oComprobantesElectronicosE.CodAtencion = (string) dr["codatencion"];
                        oComprobantesElectronicosE.CodPaciente = (string) dr["codpaciente"];
                        oComprobantesElectronicosE.NombrePaciente = (string) dr["nombrepaciente"];
                        oComprobantesElectronicosE.NombreTitular = (string) dr["nombretitular"];
                        oComprobantesElectronicosE.NombreCia = (string) dr["nombrecia"];
                        oComprobantesElectronicosE.CodPoliza = (string) dr["codpoliza"];
                        oComprobantesElectronicosE.Cama = (string) dr["cama"] + "";
                        oComprobantesElectronicosE.Ciuu = (string) dr["ciuu"] + "";
                        oComprobantesElectronicosE.Observaciones = (string) dr["observaciones"];
                        oComprobantesElectronicosE.Texto1 = (string) dr["texto1"];
                        oComprobantesElectronicosE.SucDireccion = (string) dr["suc_direccion"];
                        oComprobantesElectronicosE.MsgDetraccion = (string) dr["msgdetraccion"];
                        oComprobantesElectronicosE.MontoLetras = (string) dr["montoletras"];
                        oComprobantesElectronicosE.TipoDeCambio = (string) dr["tipodecambio"];
                        oComprobantesElectronicosE.DocReferencia = (string) dr["docreferencia"];
                        oComprobantesElectronicosE.TipoPagoTxt = (string) dr["tipopagotxt"];

                        oComprobantesElectronicosE.C_Moneda = (string) dr["c_moneda"];
                        oComprobantesElectronicosE.C_NombreMoneda = (string) dr["c_nombremoneda"];
                        oComprobantesElectronicosE.C_SimboloMoneda = (string) dr["c_simbolomoneda"];
                        oComprobantesElectronicosE.C_MontoAfecto = (string) dr["c_montoafecto"];
                        oComprobantesElectronicosE.C_MontoInafecto = (string) dr["c_montoinafecto"];
                        oComprobantesElectronicosE.C_MontoExonerado = (string) dr["c_montoexonerado"];
                        oComprobantesElectronicosE.C_MontoGratuito = (string) dr["c_montogratuito"];
                        oComprobantesElectronicosE.C_MontoIgv = (string) dr["c_montoigv"];
                        oComprobantesElectronicosE.C_MontoNeto = (string) dr["c_montoneto"];
                        oComprobantesElectronicosE.C_NetoDolares = (string) dr["c_netodolares"];
                        oComprobantesElectronicosE.PorcentajeImpuesto = (string) dr["porcentajeimpuesto"];
                        oComprobantesElectronicosE.PorcentajeCoAseguro = (string) dr["porcentajecoaseguro"];
                        oComprobantesElectronicosE.DetraccionPorc = (string)dr["detraccion_porc"];//(string) IIf(IsDBNull(dr["detraccion_porc"]), 0, dr["detraccion_porc"]);
                        oComprobantesElectronicosE.DetraccionMonto = (string)dr["detraccion_monto"];//(string) IIf(IsDBNull(dr["detraccion_monto"]), 0, dr["detraccion_monto"]);

                        oComprobantesElectronicosE.DetraccionNroCuenta = (string)dr["detraccion_nrocuenta"];//(string) IIf(IsDBNull(dr["detraccion_nrocuenta"]), 0, dr["detraccion_nrocuenta"]);
                        oComprobantesElectronicosE.FlgGratuito = (string) dr["flg_gratuito"];
                        oComprobantesElectronicosE.TipoOperacion = (string) dr["tipo_operacion"];
                        oComprobantesElectronicosE.HoraEmision = (string) dr["hora_emision"];
                        oComprobantesElectronicosE.TotalImpuesto = (string) dr["total_impuesto"];
                        oComprobantesElectronicosE.TotalValorVenta = (string) dr["total_valorventa"];
                        oComprobantesElectronicosE.TotalPrecioVenta = (string) dr["total_precioventa"];
                        oComprobantesElectronicosE.VsUbl = (string) dr["vs_ubl"];
                        oComprobantesElectronicosE.MtTotal = (string) dr["mt_total"];
                        oComprobantesElectronicosE.MtgBase = (string) dr["mtg_Base"];
                        oComprobantesElectronicosE.MtgValorImpuesto = (string) dr["mtg_ValorImpuesto"];
                        oComprobantesElectronicosE.MtgPorcentaje = (string) dr["mtg_Porcentaje"];
                        oComprobantesElectronicosE.CodigoEstabSUNAT = (string) dr["CodigoEstabSUNAT"];

                        oComprobantesElectronicosE.CodDistrito = (string) dr["CodDistrito"];
                        oComprobantesElectronicosE.FormaPago = (string) dr["forma_pago"];
                        oComprobantesElectronicosE.CodTipoDetraccion = (string) dr["cod_tipodetraccion"];
                        oComprobantesElectronicosE.CodTributo = (string) dr["cod_tributo"];
                        oComprobantesElectronicosE.CodAfectacionIGV = (string) dr["cod_afectacionIGV"];
                        oComprobantesElectronicosE.DesTributo = (string) dr["des_tributo"];
                        oComprobantesElectronicosE.CodUN = (string) dr["cod_UN"];
                        oComprobantesElectronicosE.CodProductoSUNAT = (string) dr["CodProductoSUNAT"];
                        oComprobantesElectronicosE.D_Orden = (string) dr["d_orden"];
                        oComprobantesElectronicosE.D_Unidad = (string) dr["d_unidad"];
                        oComprobantesElectronicosE.D_Grupo = (string) dr["d_grupo"];
                        oComprobantesElectronicosE.D_NombreGrupo = (string) dr["d_nombregrupo"];
                        oComprobantesElectronicosE.D_Cant_Sunat = (string) dr["d_cant_sunat"];
                        oComprobantesElectronicosE.D_VentaUnitario_SinIgv = (string) dr["d_ventaunitario_sinigv"];

                        oComprobantesElectronicosE.D_VentaUnitario_ConIgv = (string) dr["d_ventaunitario_conigv"];
                        oComprobantesElectronicosE.D_Total_SinIgv = (string) dr["d_total_sinigv"];
                        oComprobantesElectronicosE.D_Total_ConIgv = (string) dr["d_total_conigv"];
                        oComprobantesElectronicosE.D_Total_SinIgv2 = (string) dr["d_total_sinigv2"];
                        oComprobantesElectronicosE.D_MontoIgv = (string) dr["d_montoigv"];
                        oComprobantesElectronicosE.D_Determinante = (string) dr["d_determinante"];
                        oComprobantesElectronicosE.D_CodigoTipoPrecio = (string) dr["d_codigotipoprecio"];
                        oComprobantesElectronicosE.D_AfectacionIgv = (string) dr["d_afectacionigv"];
                        oComprobantesElectronicosE.Cuadre = (string) dr["cuadre"];


                        oComprobantesElectronicosE.Sunat_Tipo_FormaPago = (string) dr["sunat_tipo_formapago"] + "";
                        oComprobantesElectronicosE.Sunat_Monto_PendientePago = (string) dr["sunat_monto_pendientepago"];
                        oComprobantesElectronicosE.Sunat_Cuota_Monto = (string) dr["sunat_cuota_monto"];
                        oComprobantesElectronicosE.Sunat_Cuota_Fecha = (string) dr["sunat_cuota_fecha"] + "";
                        oComprobantesElectronicosE.Sunat_Retencion_Monto = (string) dr["sunat_retencion_monto"] + "";
                        oComprobantesElectronicosE.Sunat_Retencion_Porc = (string) dr["sunat_retencion_porc"] + "";
                        oComprobantesElectronicosE.Sunat_Retencion_MontoBase = (string) dr["sunat_retencion_montobase"] + "";
                        break;
                    }

                case 2:
                    {
                        oComprobantesElectronicosE.CodNota = (string) dr["codnota"];
                        oComprobantesElectronicosE.CodComprobanteE = (string) dr["codcomprobante_e"];
                        oComprobantesElectronicosE.TipoPlantilla = (string) dr["tipoplantilla"];
                        oComprobantesElectronicosE.TipoCompSunat = (string) dr["tipocomp_sunat"];
                        oComprobantesElectronicosE.TipoCompTci = (string) dr["tipocomp_tci"];
                        oComprobantesElectronicosE.Estado = (string) dr["estado"];
                        oComprobantesElectronicosE.NombreEstado = (string) dr["nombreestado"];
                        oComprobantesElectronicosE.ParaQuien = (string) dr["paraquien"];
                        oComprobantesElectronicosE.CodComprobanteNota = (string) dr["codcomprobate_nota"];
                        oComprobantesElectronicosE.CodLiquidacionNota = (string) dr["codliquidacion_nota"];
                        oComprobantesElectronicosE.FechaEmision = (string) dr["fechaemision"];
                        oComprobantesElectronicosE.ANombreDe = (string) (dr["anombrede"] + "").Trim();
                        oComprobantesElectronicosE.Direccion = (string) dr["direccion"];
                        oComprobantesElectronicosE.Ruc = (string) dr["ruc"] + "";
                        oComprobantesElectronicosE.TipDocIdentidadSunat = (string) dr["tipdocidentidad_sunat"];
                        oComprobantesElectronicosE.RucSunat = (string) dr["ruc_sunat"];
                        oComprobantesElectronicosE.ReceptorCorreo = (string) dr["receptor_correo"];
                        oComprobantesElectronicosE.EmpresaRuc = (string) dr["empresa_ruc"];

                        oComprobantesElectronicosE.EmpresaTipoDocIdentidad = (string) dr["empresa_tipodocidentidad"];
                        oComprobantesElectronicosE.EmpresaNombre = (string) dr["empresa_nombre"];
                        oComprobantesElectronicosE.EmpresaDireccion = (string) dr["empresa_direccion"];
                        oComprobantesElectronicosE.EmpresaTelefono = (string) dr["empresa_telefono"];
                        oComprobantesElectronicosE.Concepto = (string) dr["concepto"];
                        oComprobantesElectronicosE.CodAtencion = (string) dr["codatencion"];
                        oComprobantesElectronicosE.CodPaciente = (string) dr["codpaciente"];
                        oComprobantesElectronicosE.NombrePaciente = (string) dr["nombrepaciente"];
                        oComprobantesElectronicosE.NombreTitular = (string) dr["nombretitular"];
                        oComprobantesElectronicosE.NombreCia = (string) dr["nombrecia"];
                        oComprobantesElectronicosE.CodPoliza = (string) dr["codpoliza"];
                        oComprobantesElectronicosE.Cama = (string) dr["cama"];
                        oComprobantesElectronicosE.Ciuu = (string) dr["ciuu"] + "";
                        oComprobantesElectronicosE.Observaciones = (string) dr["observaciones"];
                        oComprobantesElectronicosE.Texto1 = (string) dr["texto1"];
                        oComprobantesElectronicosE.SucDireccion = (string) dr["suc_direccion"];
                        oComprobantesElectronicosE.MontoLetras = (string) dr["montoletras"];
                        oComprobantesElectronicosE.TipoDeCambio = (string) dr["tipodecambio"];
                        oComprobantesElectronicosE.TipoPagoTxt = (string) dr["tipopagotxt"];

                        oComprobantesElectronicosE.RefElectronico = (string) dr["ref_electronico"];
                        oComprobantesElectronicosE.RefCodComprobanteE = (string) dr["ref_codcomprobante_e"];
                        oComprobantesElectronicosE.RefTipoCompSunat = (string) dr["ref_tipocomp_sunat"];
                        oComprobantesElectronicosE.RefFechaEmision = (string) dr["ref_fechaemision"];
                        oComprobantesElectronicosE.C_CodMotivo_Sunat = (string) dr["c_codmotivo_sunat"];
                        oComprobantesElectronicosE.C_MotivoNota = (string) dr["c_motivonota"];

                        oComprobantesElectronicosE.C_Moneda = (string) dr["c_moneda"];
                        oComprobantesElectronicosE.C_NombreMoneda = (string) dr["c_nombremoneda"];
                        oComprobantesElectronicosE.C_SimboloMoneda = (string) dr["c_simbolomoneda"];
                        oComprobantesElectronicosE.C_MontoAfecto = (string) dr["c_montoafecto"];
                        oComprobantesElectronicosE.C_MontoInafecto = (string) dr["c_montoinafecto"];
                        oComprobantesElectronicosE.C_MontoExonerado = (string) dr["c_montoexonerado"];
                        oComprobantesElectronicosE.C_MontoGratuito = (string) dr["c_montogratuito"];
                        oComprobantesElectronicosE.C_MontoIgv = (string) dr["c_montoigv"];
                        oComprobantesElectronicosE.C_MontoNeto = (string) dr["c_montoneto"];

                        oComprobantesElectronicosE.C_NetoDolares = (string) dr["c_netodolares"];
                        oComprobantesElectronicosE.PorcentajeImpuesto = (string) dr["porcentajeimpuesto"];
                        oComprobantesElectronicosE.PorcentajeCoAseguro = (string) dr["porcentajecoaseguro"];
                        oComprobantesElectronicosE.FlgGratuito = (string) dr["flg_gratuito"];
                        oComprobantesElectronicosE.TipoOperacion = (string) dr["tipo_operacion"];
                        oComprobantesElectronicosE.HoraEmision = (string) dr["hora_emision"];
                        oComprobantesElectronicosE.TotalImpuesto = (string) dr["total_impuesto"];
                        oComprobantesElectronicosE.TotalValorVenta = (string) dr["total_valorventa"];
                        oComprobantesElectronicosE.TotalPrecioVenta = (string) dr["total_precioventa"];
                        oComprobantesElectronicosE.VsUbl = (string) dr["vs_ubl"];
                        oComprobantesElectronicosE.MtTotal = (string) dr["mt_total"];
                        oComprobantesElectronicosE.MtgBase = (string) dr["mtg_Base"];
                        oComprobantesElectronicosE.MtgValorImpuesto = (string) dr["mtg_ValorImpuesto"];
                        oComprobantesElectronicosE.MtgPorcentaje = (string) dr["mtg_Porcentaje"];
                        oComprobantesElectronicosE.CodigoEstabSUNAT = (string) dr["CodigoEstabSUNAT"];
                        oComprobantesElectronicosE.CodDistrito = (string) dr["CodDistrito"];
                        oComprobantesElectronicosE.FormaPago = (string) dr["forma_pago"];

                        oComprobantesElectronicosE.CodTipoDetraccion = (string) dr["cod_tipodetraccion"];
                        oComprobantesElectronicosE.CodTributo = (string) dr["cod_tributo"];
                        oComprobantesElectronicosE.CodAfectacionIGV = (string) dr["cod_afectacionIGV"];
                        oComprobantesElectronicosE.DesTributo = (string) dr["des_tributo"];
                        oComprobantesElectronicosE.CodUN = (string) dr["cod_UN"];
                        oComprobantesElectronicosE.CodProductoSUNAT = (string) dr["CodProductoSUNAT"];
                        oComprobantesElectronicosE.CodNota = (string) dr["codnota"];
                        oComprobantesElectronicosE.D_Orden = (string) dr["d_orden"];
                        oComprobantesElectronicosE.D_Unidad = (string) dr["d_unidad"];
                        oComprobantesElectronicosE.D_Grupo = (string) dr["d_grupo"];
                        oComprobantesElectronicosE.D_NombreGrupo = (string) dr["d_nombregrupo"];
                        oComprobantesElectronicosE.D_Cant_Sunat = (string) dr["d_cant_sunat"];
                        oComprobantesElectronicosE.D_VentaUnitario_SinIgv = (string) dr["d_ventaunitario_sinigv"];
                        oComprobantesElectronicosE.D_VentaUnitario_ConIgv = (string) dr["d_ventaunitario_conigv"];
                        oComprobantesElectronicosE.D_Total_SinIgv = (string) dr["d_total_sinigv"];
                        oComprobantesElectronicosE.D_Total_ConIgv = (string) dr["d_total_conigv"];
                        oComprobantesElectronicosE.D_Total_SinIgv2 = (string) dr["d_total_sinigv2"];
                        oComprobantesElectronicosE.D_MontoIgv = (string) dr["d_montoigv"];
                        oComprobantesElectronicosE.D_Determinante = (string) dr["d_determinante"];

                        oComprobantesElectronicosE.D_CodigoTipoPrecio = (string) dr["d_codigotipoprecio"];
                        oComprobantesElectronicosE.D_AfectacionIgv = (string) dr["d_afectacionigv"];
                        oComprobantesElectronicosE.Cuadre = (string) dr["cuadre"];
                        break;
                    }

                case 3 // Logistica - Ventas Notas
         :
                    {

                        // codcomprobante 'codcomprobante_e 'tipoplantilla 'tipocomp_sunat 'tipocomp_tci 'estado 'nombreestado 'fechaemision
                        oComprobantesElectronicosE.CodComprobante = (string) dr["codcomprobante"];
                        oComprobantesElectronicosE.CodComprobanteE = (string) dr["codcomprobante_e"];
                        oComprobantesElectronicosE.TipoPlantilla = (string) dr["tipoplantilla"];
                        oComprobantesElectronicosE.TipoCompSunat = (string) dr["tipocomp_sunat"];
                        oComprobantesElectronicosE.TipoCompTci = (string) dr["tipocomp_tci"];
                        oComprobantesElectronicosE.Estado = (string) dr["estado"];
                        oComprobantesElectronicosE.NombreEstado = (string) dr["nombreestado"];
                        oComprobantesElectronicosE.FechaEmision = (string) dr["fechaemision"];

                        // anombrede 'direccion 'ruc 'tipdocidentidad_sunat 'ruc_sunat 'receptor_correo 'empresa_ruc 'empresa_tipodocidentidad
                        oComprobantesElectronicosE.ANombreDe = (string) (dr["anombrede"] + "").Trim();
                        oComprobantesElectronicosE.Direccion = (string) dr["direccion"];
                        oComprobantesElectronicosE.Ruc = (string) dr["ruc"];
                        oComprobantesElectronicosE.TipDocIdentidadSunat = (string) dr["tipdocidentidad_sunat"] + "";
                        oComprobantesElectronicosE.RucSunat = (string) dr["ruc_sunat"];
                        oComprobantesElectronicosE.ReceptorCorreo = (string) dr["receptor_correo"];
                        oComprobantesElectronicosE.EmpresaRuc = (string) dr["empresa_ruc"];
                        oComprobantesElectronicosE.EmpresaTipoDocIdentidad = (string) dr["empresa_tipodocidentidad"];

                        // empresa_nombre 'empresa_direccion 'empresa_telefono 'concepto 'codatencion 'codpaciente 'nombrepaciente
                        oComprobantesElectronicosE.EmpresaNombre = (string) dr["empresa_nombre"];
                        oComprobantesElectronicosE.EmpresaDireccion = (string) dr["empresa_direccion"];
                        oComprobantesElectronicosE.EmpresaTelefono = (string) dr["empresa_telefono"];
                        oComprobantesElectronicosE.Concepto = (string) dr["concepto"];
                        oComprobantesElectronicosE.CodAtencion = (string) dr["codatencion"] + "";
                        oComprobantesElectronicosE.CodPaciente = (string) dr["codpaciente"] + "";
                        oComprobantesElectronicosE.NombrePaciente = (string) dr["nombrepaciente"];

                        // nombretitular 'nombrecia 'codpoliza 'observaciones 'texto1 'suc_direccion 'tipopagotxt 'c_moneda
                        oComprobantesElectronicosE.NombreTitular = (string) dr["nombretitular"];
                        oComprobantesElectronicosE.NombreCia = (string) dr["nombrecia"];
                        oComprobantesElectronicosE.CodPoliza = (string) dr["codpoliza"];
                        oComprobantesElectronicosE.Observaciones = (string) dr["observaciones"];
                        oComprobantesElectronicosE.Texto1 = (string) dr["texto1"];
                        oComprobantesElectronicosE.SucDireccion = (string) dr["suc_direccion"];
                        oComprobantesElectronicosE.TipoPagoTxt = (string) dr["tipopagotxt"];
                        oComprobantesElectronicosE.C_Moneda = (string) dr["c_moneda"];

                        // c_nombremoneda 'c_simbolomoneda 'c_montoafecto 'c_montoinafecto 'c_montoexonerado 'c_montogratuito
                        oComprobantesElectronicosE.C_NombreMoneda = (string) dr["c_nombremoneda"];
                        oComprobantesElectronicosE.C_SimboloMoneda = (string) dr["c_simbolomoneda"];
                        oComprobantesElectronicosE.C_MontoAfecto = (string) dr["c_montoafecto"];
                        oComprobantesElectronicosE.C_MontoInafecto = (string) dr["c_montoinafecto"];
                        oComprobantesElectronicosE.C_MontoExonerado = (string) dr["c_montoexonerado"];
                        oComprobantesElectronicosE.C_MontoGratuito = (string) dr["c_montogratuito"];

                        // c_montoigv 'c_montoneto 'porcentajeimpuesto 'porcentajecoaseguro 'd_orden 'd_unidad 'd_cant_sunat
                        oComprobantesElectronicosE.C_MontoIgv = (string) dr["c_montoigv"];
                        oComprobantesElectronicosE.C_MontoNeto = (string) dr["c_montoneto"];
                        oComprobantesElectronicosE.PorcentajeImpuesto = (string) dr["porcentajeimpuesto"];
                        oComprobantesElectronicosE.PorcentajeCoAseguro = (string) dr["porcentajecoaseguro"];
                        oComprobantesElectronicosE.D_Orden = (string) dr["d_orden"];
                        oComprobantesElectronicosE.D_Unidad = (string) dr["d_unidad"];
                        oComprobantesElectronicosE.D_Cant_Sunat = (string) dr["d_cant_sunat"];

                        // d_ventaunitario_sinigv 'd_ventaunitario_conigv 'd_total_sinigv 'd_total_conigv 'd_total_sinigv2
                        oComprobantesElectronicosE.D_VentaUnitario_SinIgv = (string) dr["d_ventaunitario_sinigv"];
                        oComprobantesElectronicosE.D_VentaUnitario_ConIgv = (string) dr["d_ventaunitario_conigv"];
                        oComprobantesElectronicosE.D_Total_SinIgv = (string) dr["d_total_sinigv"];
                        oComprobantesElectronicosE.D_Total_ConIgv = (string) dr["d_total_conigv"];
                        oComprobantesElectronicosE.D_Total_SinIgv2 = (string) dr["d_total_sinigv2"];

                        // d_montoigv 'd_determinante 'd_codigotipoprecio 'd_afectacionigv 'total_impuesto 'total_valorventa 'total_precioventa
                        oComprobantesElectronicosE.D_MontoIgv = (string) dr["d_montoigv"];
                        oComprobantesElectronicosE.D_Determinante = (string) dr["d_determinante"];
                        oComprobantesElectronicosE.D_CodigoTipoPrecio = (string) dr["d_codigotipoprecio"];
                        oComprobantesElectronicosE.D_AfectacionIgv = (string) dr["d_afectacionigv"];
                        oComprobantesElectronicosE.TotalImpuesto = (string) dr["total_impuesto"];
                        oComprobantesElectronicosE.TotalValorVenta = (string) dr["total_valorventa"];
                        oComprobantesElectronicosE.TotalPrecioVenta = (string) dr["total_precioventa"];

                        // vs_ubl 'mt_total 'mtg_Base 'mtg_ValorImpuesto 'mtg_Porcentaje 'CodigoEstabSUNAT 'cod_tributo 'cod_afectacionIGV
                        oComprobantesElectronicosE.VsUbl = (string) dr["vs_ubl"];
                        oComprobantesElectronicosE.MtTotal = (string) dr["mt_total"];
                        oComprobantesElectronicosE.MtgBase = (string) dr["mtg_Base"];
                        oComprobantesElectronicosE.MtgValorImpuesto = (string) dr["mtg_ValorImpuesto"];
                        oComprobantesElectronicosE.MtgPorcentaje = (string) dr["mtg_Porcentaje"];
                        oComprobantesElectronicosE.CodigoEstabSUNAT = (string) dr["CodigoEstabSUNAT"];
                        oComprobantesElectronicosE.CodTributo = (string) dr["cod_tributo"];
                        oComprobantesElectronicosE.CodAfectacionIGV = (string) dr["cod_afectacionIGV"];

                        // des_tributo 'cod_UN 'CodProductoSUNAT 'cuadre
                        oComprobantesElectronicosE.DesTributo = (string) dr["des_tributo"];
                        oComprobantesElectronicosE.CodUN = (string) dr["cod_UN"];
                        oComprobantesElectronicosE.CodProductoSUNAT = (string) dr["CodProductoSUNAT"];
                        oComprobantesElectronicosE.Cuadre = (string) (dr["cuadre"] + "").Trim();

                        // --------------------------
                        // paraquien 'codliquidacion 'cama 'ciuu
                        // oComprobantesElectronicosE.ParaQuien = (string) dr["paraquien") + ""
                        // oComprobantesElectronicosE.CodLiquidacion = dr["codliquidacion") + ""
                        // oComprobantesElectronicosE.Cama = dr["cama") + ""
                        // oComprobantesElectronicosE.Ciuu = dr["ciuu") + ""

                        // 'msgdetraccion 'montoletras 'tipodecambio 'docreferencia 'c_netodolares
                        // oComprobantesElectronicosE.MsgDetraccion = dr["msgdetraccion")
                        // oComprobantesElectronicosE.MontoLetras = dr["montoletras")
                        // oComprobantesElectronicosE.TipoDeCambio = dr["tipodecambio")
                        // oComprobantesElectronicosE.DocReferencia = dr["docreferencia")
                        // oComprobantesElectronicosE.C_NetoDolares = dr["c_netodolares")

                        // 'd_grupo 'd_nombregrupo 'detraccion_porc 'detraccion_monto 'detraccion_nrocuenta
                        // oComprobantesElectronicosE.D_Grupo = dr["d_grupo")
                        // oComprobantesElectronicosE.D_NombreGrupo = dr["d_nombregrupo")
                        // oComprobantesElectronicosE.DetraccionPorc = IIf(IsDBNull(dr["detraccion_porc")), 0, dr["detraccion_porc"))
                        // oComprobantesElectronicosE.DetraccionMonto = IIf(IsDBNull(dr["detraccion_monto")), 0, dr["detraccion_monto"))
                        // oComprobantesElectronicosE.DetraccionNroCuenta = IIf(IsDBNull(dr["detraccion_nrocuenta")), 0, dr["detraccion_nrocuenta"))

                        // flg_gratuito 'tipo_operacion 'hora_emision 'CodDistrito
                        oComprobantesElectronicosE.FlgGratuito = (string) dr["flg_gratuito"];
                        oComprobantesElectronicosE.TipoOperacion = (string) dr["tipo_operacion"];
                        oComprobantesElectronicosE.HoraEmision = (string) dr["hora_emision"];
                        oComprobantesElectronicosE.CodDistrito = (string) dr["CodDistrito"];

                        // forma_pago 'cod_tipodetraccion 
                        oComprobantesElectronicosE.FormaPago = (string) dr["forma_pago"] + "";
                        // oComprobantesElectronicosE.CodTipoDetraccion = dr["cod_tipodetraccion") + ""

                        oComprobantesElectronicosE.D_Dscto_Unitario = (string) dr["d_dscto_unitario"];
                        oComprobantesElectronicosE.D_Total_ConDsctoIGV = (string) dr["d_total_condsctoigv"];
                        oComprobantesElectronicosE.D_Dscto_MontoBase = (string) dr["d_dscto_montobase"];

                        // d_dscto_conigv     d_montoaseguradora  d_dscto_sinigv	    d_montobase	
                        oComprobantesElectronicosE.D_Dscto_ConIGV = (string) dr["d_dscto_conigv"];
                        oComprobantesElectronicosE.D_MontoAseguradora = (string) dr["d_montoaseguradora"];
                        oComprobantesElectronicosE.D_Dscto_SinIGV = (string) dr["d_dscto_sinigv"];
                        oComprobantesElectronicosE.D_MontoBase = (string) dr["d_montobase"];
                        break;
                    }

                case 4 // Notas de Credito Logistica
         :
                    {
                        // codcomprobante  codcomprobante_e	tipoplantilla	tipocomp_sunat	tipocomp_tci	
                        oComprobantesElectronicosE.CodComprobante = (string)dr["codcomprobante"];
                        oComprobantesElectronicosE.CodComprobanteE = (string)dr["codcomprobante_e"];
                        oComprobantesElectronicosE.TipoPlantilla = (string)dr["tipoplantilla"];
                        oComprobantesElectronicosE.TipoCompSunat = (string)dr["tipocomp_sunat"];
                        oComprobantesElectronicosE.TipoCompTci = (string)dr["tipocomp_tci"];

                        // estado  nombreestado	fechaemision
                        oComprobantesElectronicosE.Estado = (string)dr["estado"];
                        oComprobantesElectronicosE.NombreEstado = (string)dr["nombreestado"];
                        oComprobantesElectronicosE.FechaEmision = (string)dr["fechaemision"];

                        // anombrede   direccion	ruc	tipdocidentidad_sunat	ruc_sunat	
                        oComprobantesElectronicosE.ANombreDe = (string) (dr["anombrede"] + "").Trim();
                        oComprobantesElectronicosE.Direccion = (string)dr["direccion"];
                        oComprobantesElectronicosE.Ruc = (string)dr["ruc"];
                        oComprobantesElectronicosE.TipDocIdentidadSunat = (string)dr["tipdocidentidad_sunat"] + "";
                        oComprobantesElectronicosE.RucSunat = (string)dr["ruc_sunat"];

                        // receptor_correo empresa_ruc	empresa_tipodocidentidad	empresa_nombre	
                        oComprobantesElectronicosE.ReceptorCorreo = (string)dr["receptor_correo"];
                        oComprobantesElectronicosE.EmpresaRuc = (string)dr["empresa_ruc"];
                        oComprobantesElectronicosE.EmpresaTipoDocIdentidad = (string)dr["empresa_tipodocidentidad"];
                        oComprobantesElectronicosE.EmpresaNombre = (string)dr["empresa_nombre"];

                        // empresa_direccion   empresa_telefono	concepto	codatencion	codpaciente	
                        oComprobantesElectronicosE.EmpresaDireccion = (string)dr["empresa_direccion"];
                        oComprobantesElectronicosE.EmpresaTelefono = (string)dr["empresa_telefono"];
                        oComprobantesElectronicosE.Concepto = (string)dr["concepto"];
                        oComprobantesElectronicosE.CodAtencion = (string)dr["codatencion"];
                        oComprobantesElectronicosE.CodPaciente = (string)dr["codpaciente"];

                        // nombrepaciente  nombretitular	nombrecia	codpoliza	observaciones
                        oComprobantesElectronicosE.NombrePaciente = (string)dr["nombrepaciente"];
                        oComprobantesElectronicosE.NombreTitular = (string)dr["nombretitular"];
                        oComprobantesElectronicosE.NombreCia = (string)dr["nombrecia"] + "";
                        oComprobantesElectronicosE.CodPoliza = (string)dr["codpoliza"];
                        oComprobantesElectronicosE.Observaciones = (string)dr["observaciones"];

                        // texto1  suc_direccion	tipopagotxt ref_electronico	ref_codcomprobante_e	ref_tipocomp_sunat	
                        oComprobantesElectronicosE.Texto1 = (string)dr["texto1"];
                        oComprobantesElectronicosE.SucDireccion = (string)dr["suc_direccion"];
                        oComprobantesElectronicosE.TipoPagoTxt = (string)dr["tipopagotxt"];
                        oComprobantesElectronicosE.RefElectronico = (string)dr["ref_electronico"];
                        oComprobantesElectronicosE.RefCodComprobanteE = (string)dr["ref_codcomprobante_e"];
                        oComprobantesElectronicosE.RefTipoCompSunat = (string)dr["ref_tipocomp_sunat"];

                        // ref_fechaemision    c_codmotivo_sunat	c_motivonota	
                        oComprobantesElectronicosE.RefFechaEmision = (string)dr["ref_fechaemision"];
                        oComprobantesElectronicosE.C_CodMotivo_Sunat = (string)dr["c_codmotivo_sunat"];
                        oComprobantesElectronicosE.C_MotivoNota = (string)dr["c_motivonota"];

                        // c_moneda    c_nombremoneda  c_simbolomoneda 	c_montoafecto	c_montoinafecto	c_montoexonerado
                        oComprobantesElectronicosE.C_Moneda = (string)dr["c_moneda"];
                        oComprobantesElectronicosE.C_NombreMoneda = (string)dr["c_nombremoneda"];
                        oComprobantesElectronicosE.C_SimboloMoneda = (string)dr["c_simbolomoneda"];
                        oComprobantesElectronicosE.C_MontoAfecto = (string)dr["c_montoafecto"];
                        oComprobantesElectronicosE.C_MontoInafecto = (string)dr["c_montoinafecto"];
                        oComprobantesElectronicosE.C_MontoExonerado = (string)dr["c_montoexonerado"];

                        // c_montogratuito c_montoigv	c_montoneto	porcentajeimpuesto	porcentajecoaseguro	
                        oComprobantesElectronicosE.C_MontoGratuito = (string)dr["c_montogratuito"];
                        oComprobantesElectronicosE.C_MontoIgv = (string)dr["c_montoigv"];
                        oComprobantesElectronicosE.C_MontoNeto = (string)dr["c_montoneto"];
                        oComprobantesElectronicosE.PorcentajeImpuesto = (string)dr["porcentajeimpuesto"];
                        oComprobantesElectronicosE.PorcentajeCoAseguro = (string)dr["porcentajecoaseguro"];

                        // flg_gratuito    d_orden	d_unidad	d_cant_sunat	
                        oComprobantesElectronicosE.FlgGratuito = (string)dr["flg_gratuito"];
                        oComprobantesElectronicosE.D_Orden = (string)dr["d_orden"];
                        oComprobantesElectronicosE.D_Unidad = (string)dr["d_unidad"];
                        oComprobantesElectronicosE.D_Cant_Sunat = (string)dr["d_cant_sunat"];

                        // ------------------------------
                        // d_codproducto	nombreproducto	
                        oComprobantesElectronicosE.D_CodProducto = (string)dr["d_codproducto"];
                        oComprobantesElectronicosE.NombreProducto = (string)dr["nombreproducto"];

                        // d_stockfraccion d_cantidad	d_cantidad_fraccion	d_valorVVP	d_precioventaPVP
                        oComprobantesElectronicosE.D_StockFraccion = (string)dr["d_stockfraccion"];
                        oComprobantesElectronicosE.D_Cantidad = (string)dr["d_cantidad"];
                        oComprobantesElectronicosE.D_Cantidad_Fraccion = (string)dr["d_cantidad_fraccion"];
                        oComprobantesElectronicosE.D_ValorVVP = (string)dr["d_valorVVP"];
                        oComprobantesElectronicosE.D_PrecioVentaPVP = (string)dr["d_precioventaPVP"];

                        // d_porcdctoproducto  d_porcdctoplan	d_preciounidadcondcto	d_montototal	d_montopaciente	
                        oComprobantesElectronicosE.D_PorcDctoProducto = (string)dr["d_porcdctoproducto"];
                        oComprobantesElectronicosE.D_PorcDctoPlan = (string)dr["d_porcdctoplan"];
                        oComprobantesElectronicosE.D_PrecioUnidadConDcto = (string)dr["d_preciounidadcondcto"];
                        oComprobantesElectronicosE.D_MontoTotal = (string)dr["d_montototal"];
                        oComprobantesElectronicosE.D_MontoPaciente = (string)dr["d_montopaciente"];
                        // ----------------------------------


                        // d_ventaunitario_sinigv  d_ventaunitario_conigv  
                        oComprobantesElectronicosE.D_VentaUnitario_SinIgv = (string)dr["d_ventaunitario_sinigv"];
                        oComprobantesElectronicosE.D_VentaUnitario_ConIgv = (string)dr["d_ventaunitario_conigv"];

                        // d_total_sinigv	d_total_conigv	d_total_sinigv2	d_montoigv	d_determinante	
                        oComprobantesElectronicosE.D_Total_SinIgv = (string)dr["d_total_sinigv"];
                        oComprobantesElectronicosE.D_Total_ConIgv = (string)dr["d_total_conigv"];
                        oComprobantesElectronicosE.D_Total_SinIgv2 = (string)dr["d_total_sinigv2"];
                        oComprobantesElectronicosE.D_MontoIgv = (string)dr["d_montoigv"];
                        oComprobantesElectronicosE.D_Determinante = (string)dr["d_determinante"];

                        // d_codigotipoprecio  d_afectacionigv	
                        oComprobantesElectronicosE.D_CodigoTipoPrecio = (string)dr["d_codigotipoprecio"];
                        oComprobantesElectronicosE.D_AfectacionIgv = (string)dr["d_afectacionigv"];

                        // tipo_operacion  hora_emision    total_impuesto  total_valorventa	total_precioventa	vs_ubl	mt_total	
                        oComprobantesElectronicosE.TipoOperacion = (string)dr["tipo_operacion"];
                        oComprobantesElectronicosE.HoraEmision = (string)dr["hora_emision"];
                        oComprobantesElectronicosE.TotalImpuesto = (string)dr["total_impuesto"];
                        oComprobantesElectronicosE.TotalValorVenta = (string)dr["total_valorventa"];
                        oComprobantesElectronicosE.TotalPrecioVenta = (string)dr["total_precioventa"];
                        oComprobantesElectronicosE.VsUbl = (string)dr["vs_ubl"];
                        oComprobantesElectronicosE.MtTotal = (string)dr["mt_total"];

                        // mtg_Base mtg_ValorImpuesto   mtg_Porcentaje	
                        oComprobantesElectronicosE.MtgBase = (string)dr["mtg_Base"];
                        oComprobantesElectronicosE.MtgValorImpuesto = (string)dr["mtg_ValorImpuesto"];
                        oComprobantesElectronicosE.MtgPorcentaje = (string)dr["mtg_Porcentaje"];

                        // CodigoEstabSUNAT    CodDistrito	forma_pago	    cod_tributo cod_afectacionIGV   
                        oComprobantesElectronicosE.CodigoEstabSUNAT = (string)dr["CodigoEstabSUNAT"];
                        oComprobantesElectronicosE.CodDistrito = (string)dr["CodDistrito"];
                        oComprobantesElectronicosE.FormaPago = (string)dr["forma_pago"];
                        oComprobantesElectronicosE.CodTributo = (string)dr["cod_tributo"];
                        oComprobantesElectronicosE.CodAfectacionIGV = (string)dr["cod_afectacionIGV"];

                        // des_tributo cod_UN	CodProductoSUNAT	cuadre
                        oComprobantesElectronicosE.DesTributo = (string)dr["des_tributo"];
                        oComprobantesElectronicosE.CodUN = (string)dr["cod_UN"];
                        oComprobantesElectronicosE.CodProductoSUNAT = (string)dr["CodProductoSUNAT"];
                        oComprobantesElectronicosE.Cuadre = (string)dr["cuadre"];

                        // ----------------------------------------------------------
                        // codtipocliente  tipomovimiento	codventa    c_montodsctoplan
                        oComprobantesElectronicosE.CodTipoCliente = (string)dr["codtipocliente"];
                        oComprobantesElectronicosE.TipoMovimiento = (string)dr["tipomovimiento"];
                        oComprobantesElectronicosE.CodVenta = (string)dr["codventa"];
                        oComprobantesElectronicosE.C_MontoDsctoPlan = (string)dr["c_montodsctoplan"];

                        // d_dscto_unitario	d_total_condsctoigv	d_dscto_montobase	
                        oComprobantesElectronicosE.D_Dscto_Unitario = (string)dr["d_dscto_unitario"];
                        oComprobantesElectronicosE.D_Total_ConDsctoIGV = (string)dr["d_total_condsctoigv"];
                        oComprobantesElectronicosE.D_Dscto_MontoBase = (string)dr["d_dscto_montobase"];

                        // d_dscto_conigv     d_montoaseguradora  d_dscto_sinigv	    d_montobase	
                        oComprobantesElectronicosE.D_Dscto_ConIGV = (string)dr["d_dscto_conigv"];
                        oComprobantesElectronicosE.D_MontoAseguradora = (string)dr["d_montoaseguradora"];
                        oComprobantesElectronicosE.D_Dscto_SinIGV = (string)dr["d_dscto_sinigv"];
                        oComprobantesElectronicosE.D_MontoBase = (string)dr["d_montobase"];
                        // ----------------------------------------------------------

                        oComprobantesElectronicosE.Sunat_Tipo_FormaPago = (string)dr["sunat_tipo_formapago"] + "";
                        oComprobantesElectronicosE.Sunat_Monto_PendientePago = (string)dr["sunat_monto_pendientepago"] + "";
                        oComprobantesElectronicosE.Sunat_Cuota_Monto = (string)dr["sunat_cuota_monto"] + "";
                        oComprobantesElectronicosE.Sunat_Cuota_Fecha = (string)dr["sunat_cuota_fecha"] + "";
                        oComprobantesElectronicosE.Sunat_Retencion_Monto = (string) dr["sunat_retencion_monto"] + "";
                        oComprobantesElectronicosE.Sunat_Retencion_Porc = (string) dr["sunat_retencion_porc"] + "";
                        oComprobantesElectronicosE.Sunat_Retencion_MontoBase = (string) dr["sunat_retencion_montobase"] + "";
                        break;
                    }
            }

            return oComprobantesElectronicosE;
        }

        public List<ComprobantesElectronicosE> Sp_ComprobantesElectronicos_Consulta(ComprobantesElectronicosE pComprobantesElectronicosE)
        {
            IDataReader dr;
            ComprobantesElectronicosE oComprobantesElectronicosE; 
            List<ComprobantesElectronicosE> oListar = new List<ComprobantesElectronicosE>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_ComprobantesElectronicos_Consulta", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@orden", pComprobantesElectronicosE.Orden);
                        cnn.Open();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            oComprobantesElectronicosE = LlenarEntidad(dr, pComprobantesElectronicosE);
                            oListar.Add(oComprobantesElectronicosE);
                        }
                        dr.Close();
                        cnn.Close();

                        return oListar;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<ComprobanteElectronicoXMLCabE> Sp_ComprobantesElectronicosCSF_XML_Cab(ComprobantesElectronicosE pComprobantesElectronicosE)
        {
            IDataReader dr;
            ComprobanteElectronicoXMLCabE oComprobantesElectronicosE;
            List<ComprobanteElectronicoXMLCabE> oListar = new List<ComprobanteElectronicoXMLCabE>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_ComprobantesElectronicosCSF_XML_Cab", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@codcomprobante", pComprobantesElectronicosE.Codcomprobante);
                        cnn.Open();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            oComprobantesElectronicosE = LlenarEntidadXMLCab(dr, 1);
                            oListar.Add(oComprobantesElectronicosE);
                        }
                        dr.Close();
                        cnn.Close();

                        return oListar;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<ComprobanteElectronicoXMLCabE> Sp_NotaElectronicaCSF_XML(ComprobantesElectronicosE pComprobantesElectronicosE)
        {
            IDataReader dr;
            ComprobanteElectronicoXMLCabE oComprobantesElectronicosE;
            List<ComprobanteElectronicoXMLCabE> oListar = new List<ComprobanteElectronicoXMLCabE>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_NotaElectronicaCSF_XML", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@codnota", pComprobantesElectronicosE.Codcomprobante);
                        cmd.Parameters.AddWithValue("@codempresa", pComprobantesElectronicosE.Codempresa);
                        cnn.Open();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            oComprobantesElectronicosE = LlenarEntidadXMLCab(dr, 2);
                            oListar.Add(oComprobantesElectronicosE);
                        }
                        dr.Close();
                        cnn.Close();

                        return oListar;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<ComprobanteElectronicoXMLCabE> Sp_ComprobantesElectronicosLOG_XML_Cab(ComprobantesElectronicosE pComprobantesElectronicosE)
        {
            IDataReader dr;
            ComprobanteElectronicoXMLCabE oComprobantesElectronicosE;
            List<ComprobanteElectronicoXMLCabE> oListar = new List<ComprobanteElectronicoXMLCabE>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("MediVentas..Sp_ComprobantesElectronicosLOG_XML_Cab", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@codcomprobante", pComprobantesElectronicosE.Codcomprobante);
                        cmd.Parameters.AddWithValue("@orden", 0);
                        cnn.Open();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            oComprobantesElectronicosE = LlenarEntidadXMLCab(dr, 3);
                            oListar.Add(oComprobantesElectronicosE);
                        }
                        dr.Close();
                        cnn.Close();

                        return oListar;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<ComprobanteElectronicoXMLCabE> Sp_NotaElectronicaLOG_XML(ComprobantesElectronicosE pComprobantesElectronicosE)
        {
            IDataReader dr;
            ComprobanteElectronicoXMLCabE oComprobantesElectronicosE;
            List<ComprobanteElectronicoXMLCabE> oListar = new List<ComprobanteElectronicoXMLCabE>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("MediVentas..Sp_NotaElectronicaLOG_XML", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@codnota", pComprobantesElectronicosE.Codcomprobante);
                        cmd.Parameters.AddWithValue("@orden", 0);
                        cnn.Open();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            oComprobantesElectronicosE = LlenarEntidadXMLCab(dr, 4);
                            oListar.Add(oComprobantesElectronicosE);
                        }
                        dr.Close();
                        cnn.Close();

                        return oListar;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Sp_ComprobantesElectronicos_Update(ComprobantesElectronicosE pComprobantesElectronicosE)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(VariablesGlobales.CnnClinica))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_ComprobantesElectronicos_Update", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Parametros del Store
                        cmd.Parameters.AddWithValue("@codigo", pComprobantesElectronicosE.Codcomprobante);
                        cmd.Parameters.AddWithValue("@campo", pComprobantesElectronicosE.Campo);
                        cmd.Parameters.AddWithValue("@nuevovalor", pComprobantesElectronicosE.NuevoValor);
                        cmd.Parameters.AddWithValue("@xml", pComprobantesElectronicosE.XmlRegistro);
                        cmd.Parameters.AddWithValue("@codigobarrajpg", pComprobantesElectronicosE.CodigoBarra);

                        cnn.Open();
                        if (cmd.ExecuteNonQuery() >= 1)
                            return true;
                        else
                            return false;
                        cnn.Close();
                        cmd.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
