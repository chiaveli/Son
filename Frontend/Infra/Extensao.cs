using BlazorBootstrap;
using System.IO.Pipelines;

namespace Son.Infra
{
    public static class Extensao
    {
        public static async Task Mostrar(this ModalService pModalService, string pMensagem, string pTitulo = "Atenção", ModalType pTipo = ModalType.Info)
        {
            var opcao = new ModalOption
            {
                Title = pTitulo,
                Message = pMensagem,
                Type = pTipo,
            };

            await pModalService.ShowAsync(opcao);
        }

        public static async Task<Boolean> Confirmar(this ConfirmDialog pDialog, string pTexto, string pTitulo = "Confirma?")
        {
            var options = new ConfirmDialogOptions
            {
                YesButtonText = "Sim",
                YesButtonColor = ButtonColor.Success,
                NoButtonText = "Nao",
                NoButtonColor = ButtonColor.Danger
            };

            return await pDialog.ShowAsync(pTitulo, pTexto,options);
        }
    }
}


