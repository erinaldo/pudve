﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// Microsoft.VSDesigner generó automáticamente este código fuente, versión=4.0.30319.42000.
// 
#pragma warning disable 1591

namespace PuntoDeVentaV2.FH_CFDI40_produccion {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="WsEmisionTimbrado40PortBinding", Namespace="http://cfdi.ws4.facturehoy.certus.com/")]
    public partial class WsEmisionTimbrado40 : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback EmitirTimbrarOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public WsEmisionTimbrado40() {
            this.Url = global::PuntoDeVentaV2.Properties.Settings.Default.PuntoDeVentaV2_FH_CFDI40_produccion_WsEmisionTimbrado40;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event EmitirTimbrarCompletedEventHandler EmitirTimbrarCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace="http://cfdi.ws4.facturehoy.certus.com/", ResponseNamespace="http://cfdi.ws4.facturehoy.certus.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public wsResponseBO EmitirTimbrar([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string usuario, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string contrasenia, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] int idServicio, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="base64Binary", IsNullable=true)] byte[] xml) {
            object[] results = this.Invoke("EmitirTimbrar", new object[] {
                        usuario,
                        contrasenia,
                        idServicio,
                        xml});
            return ((wsResponseBO)(results[0]));
        }
        
        /// <remarks/>
        public void EmitirTimbrarAsync(string usuario, string contrasenia, int idServicio, byte[] xml) {
            this.EmitirTimbrarAsync(usuario, contrasenia, idServicio, xml, null);
        }
        
        /// <remarks/>
        public void EmitirTimbrarAsync(string usuario, string contrasenia, int idServicio, byte[] xml, object userState) {
            if ((this.EmitirTimbrarOperationCompleted == null)) {
                this.EmitirTimbrarOperationCompleted = new System.Threading.SendOrPostCallback(this.OnEmitirTimbrarOperationCompleted);
            }
            this.InvokeAsync("EmitirTimbrar", new object[] {
                        usuario,
                        contrasenia,
                        idServicio,
                        xml}, this.EmitirTimbrarOperationCompleted, userState);
        }
        
        private void OnEmitirTimbrarOperationCompleted(object arg) {
            if ((this.EmitirTimbrarCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.EmitirTimbrarCompleted(this, new EmitirTimbrarCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://cfdi.ws4.facturehoy.certus.com/")]
    public partial class wsResponseBO {
        
        private byte[] acuseField;
        
        private byte[][] arregloAcuseField;
        
        private string cadenaOriginalField;
        
        private string cadenaOriginalTimbreField;
        
        private int codigoErrorField;
        
        private System.DateTime fechaHoraTimbradoField;
        
        private bool fechaHoraTimbradoFieldSpecified;
        
        private string folioUDDIField;
        
        private bool isErrorField;
        
        private bool isErrorFieldSpecified;
        
        private string messageField;
        
        private byte[] pDFField;
        
        private string rutaDescargaPDFField;
        
        private string rutaDescargaXMLField;
        
        private string selloDigitalEmisorField;
        
        private string selloDigitalTimbreSATField;
        
        private byte[] xMLField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="base64Binary")]
        public byte[] acuse {
            get {
                return this.acuseField;
            }
            set {
                this.acuseField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("arregloAcuse", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="base64Binary", IsNullable=true)]
        public byte[][] arregloAcuse {
            get {
                return this.arregloAcuseField;
            }
            set {
                this.arregloAcuseField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string cadenaOriginal {
            get {
                return this.cadenaOriginalField;
            }
            set {
                this.cadenaOriginalField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string cadenaOriginalTimbre {
            get {
                return this.cadenaOriginalTimbreField;
            }
            set {
                this.cadenaOriginalTimbreField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int codigoError {
            get {
                return this.codigoErrorField;
            }
            set {
                this.codigoErrorField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public System.DateTime fechaHoraTimbrado {
            get {
                return this.fechaHoraTimbradoField;
            }
            set {
                this.fechaHoraTimbradoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool fechaHoraTimbradoSpecified {
            get {
                return this.fechaHoraTimbradoFieldSpecified;
            }
            set {
                this.fechaHoraTimbradoFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string folioUDDI {
            get {
                return this.folioUDDIField;
            }
            set {
                this.folioUDDIField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public bool isError {
            get {
                return this.isErrorField;
            }
            set {
                this.isErrorField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool isErrorSpecified {
            get {
                return this.isErrorFieldSpecified;
            }
            set {
                this.isErrorFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string message {
            get {
                return this.messageField;
            }
            set {
                this.messageField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="base64Binary")]
        public byte[] PDF {
            get {
                return this.pDFField;
            }
            set {
                this.pDFField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string rutaDescargaPDF {
            get {
                return this.rutaDescargaPDFField;
            }
            set {
                this.rutaDescargaPDFField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string rutaDescargaXML {
            get {
                return this.rutaDescargaXMLField;
            }
            set {
                this.rutaDescargaXMLField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string selloDigitalEmisor {
            get {
                return this.selloDigitalEmisorField;
            }
            set {
                this.selloDigitalEmisorField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string selloDigitalTimbreSAT {
            get {
                return this.selloDigitalTimbreSATField;
            }
            set {
                this.selloDigitalTimbreSATField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="base64Binary")]
        public byte[] XML {
            get {
                return this.xMLField;
            }
            set {
                this.xMLField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void EmitirTimbrarCompletedEventHandler(object sender, EmitirTimbrarCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class EmitirTimbrarCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal EmitirTimbrarCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public wsResponseBO Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((wsResponseBO)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591