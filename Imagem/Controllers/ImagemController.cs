using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Imagem.Models;

namespace Imagem.Controllers
{
    public class ImagemController : Controller
    {
        ImagemEntities db = new ImagemEntities();
        // GET: Imagem
        public ActionResult Index()
        {
            //enviando para a view o conteudo do entitie( vindo da Tabela) 
            // se utilizar o comando Find(id), poderá retornar uma registro especifico.
            return View(db.exemploes.ToList());
        }

        // GET: Imagem
        public ActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Adicionar(exemplo imagem)
        {
            //verifica se está sendo adicionada uma imagem
            if (imagem.ImageFile != null)
            {
                // as Duas variaveis abaixo irá extrar o nome e a extensão do arquivo do usuário
                string filename = Path.GetFileNameWithoutExtension(imagem.ImageFile.FileName);
                string extension = Path.GetExtension(imagem.ImageFile.FileName);
                // iremos criar um novo nome do arquivo, adicionando a data que foi salvo
                // evita que de erro ao tentar salvar dois arquivos com o mesmo nome. Não é 100%
                filename = filename + DateTime.Now.ToString("ddmmss") + extension;
                // adiciona o caminho da pasta ao nome do arquivo gerado e 
                // salva a string com o caminho completo no model (que será salvo no BD)
                imagem.caminhoImagem = "~/Imagens/" + filename;
                // as duas linhas abaixo é para copiar o arquivo do usuario na pasta
                // da aplicação ( no caso copia a imagem para a pasta Imagens).
                filename = Path.Combine(Server.MapPath("~/Imagens/"), filename);
                imagem.ImageFile.SaveAs(filename);
            }
            // o if verifica se as restrições do model foram atendidas
            if (ModelState.IsValid)
            {
                //Adicionando os valores( vindo da View) ao entitie.
                db.exemploes.Add(imagem);
                //Salvando no Banco de dados via ORM, os dados do
                // entitie na tabela correspondente.
                db.SaveChanges();
                // Apos salvar o usuário será redirecionado para a página de index.
                return RedirectToAction("Index");
            }
            ModelState.Clear();
            return View();
        }

        // GET: /imagem/Delete/5

        public ActionResult Delete(int id)
        {
            // Irá fazer uma busca nos registros pelo Id 
            // enviado pela view Index
            exemplo deleta = db.exemploes.Find(id);
             if (deleta == null)
            {
                return HttpNotFound();
            }
             if (deleta.caminhoImagem == null)
            {
                deleta.caminhoImagem = "~/Imagens/semimagem.jpg";
            }
            
            return View(deleta);
        }
        // POST: /Funcionario/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmar(int id)
        {
            // Irá fazer uma busca nos registros pelo Id 
            // enviado pela view Index
            exemplo deleta = db.exemploes.Find(id);
            db.exemploes.Remove(deleta);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}