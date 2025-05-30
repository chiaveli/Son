using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Son.Comum.Infra
{
    public static class Cifra
    {
        private static List<string> matrizS = new List<string>();
        private static List<string> matrizB = new List<string>();

        private static string regNotas     = "[CDEFGAB]";
        private static string regAcidentes = "(b|bb)?";
        private static string regAcords    = "(m|maj7|maj|min7|min|sus)?";
        private static string regSuspends  = "(1|2|3|4|5|6|7|8|9)?";
        private static string regSustenido = "(#)?";
        private static string regFinal;

        static Cifra()
        {
            matrizS.Add("C");
            matrizS.Add("C#");
            matrizS.Add("D");
            matrizS.Add("D#");
            matrizS.Add("E");
            matrizS.Add("F");
            matrizS.Add("F#");
            matrizS.Add("G");
            matrizS.Add("G#");
            matrizS.Add("A");
            matrizS.Add("A#");
            matrizS.Add("B");

            matrizB.Add("C");
            matrizB.Add("Db");
            matrizB.Add("D");
            matrizB.Add("Eb");
            matrizB.Add("E");
            matrizB.Add("F");
            matrizB.Add("Gb");
            matrizB.Add("G");
            matrizB.Add("Ab");
            matrizB.Add("A");
            matrizB.Add("Bb");
            matrizB.Add("B");

            regFinal = $@"\b{regNotas}{regAcidentes}{regAcords}{regSuspends}\b{regSustenido}";
        }

        /// <summary>
        ///  Muda o tom dos acordes do texto que representa a letra da música
        /// </summary>
        /// <param name="pLetra">Um texto contendo a letra da música com as cifras/acordes</param>
        /// <param name="pEscala">Valor positivo sobe o tom, valor negativo desce o tom</param>
        /// <returns>O texto da letra com o tom dos acordes alterados</returns>
        public static string MudarTomLetra(string pLetra, int pEscala = 1)
        {
            string linha, novaLinha;
            string[] letra = pLetra.Split('\n');
            string retorno = "";

            for (int i = 0; i < letra.Length; i++)
            {
                linha = letra[i];
                novaLinha = Cifra.MudarTomCifra(linha, pEscala);

                if (novaLinha != linha)
                    retorno += novaLinha + Environment.NewLine;
                else
                    retorno += letra[i] + Environment.NewLine;
            }

            return retorno.TrimEnd();
        }

        /// <summary>
        /// Muda o tom dos acordes do texto que representa uma linha com a cifra da música
        /// </summary>
        /// <param name="pCifra">Um linha contendo um ou varios acordes</param>
        /// <param name="pEscala">Valor positivo sobe o tom, valor negativo desce o tom</param>
        /// <returns>A linha com o tom dos acordes alterados</returns>
        public static string MudarTomCifra(string pCifra, int pEscala = 1)
        {
            string nota, retornoTransposicao, baixo, acordeSemEspaco, acordeOriginal;
            bool heCifra;

            pCifra = pCifra.Replace(@"\", "/");

            string[] cifra = pCifra.Split(' ');

            for (int i = 0; i < cifra.Length; i++)
            {
                acordeOriginal = cifra[i];

                acordeSemEspaco = acordeOriginal.Trim();

                heCifra = Regex.IsMatch(acordeSemEspaco, regFinal);

                if (!heCifra)
                    continue;

                if (acordeSemEspaco.Length == 0)
                    continue;

                if (acordeSemEspaco.Length == 1)
                    nota = acordeSemEspaco;
                else
                {
                    if ("#,b".Contains(cifra[i].Trim().Substring(1, 1)))
                        nota = acordeSemEspaco.Substring(0, 2);
                    else
                        nota = acordeSemEspaco.Substring(0, 1);
                }

                retornoTransposicao = MudarTomNota(nota, pEscala);

                cifra[i] = cifra[i].Replace(nota, retornoTransposicao);

                nota = cifra[i];

                if (nota.Contains("/"))
                {
                    baixo = nota.Substring(nota.IndexOf("/") + 1);
                    retornoTransposicao = MudarTomNota(baixo, pEscala);
                    cifra[i] = cifra[i].Replace(baixo, retornoTransposicao);
                }
            }

            return String.Join(" ", cifra);
        }

        /// <summary>
        /// Muda o tom de um acorde
        /// </summary>
        /// <param name="pAcord">O acorede</param>
        /// <param name="pEscala">Valor positivo sobe o tom, valor negativo desce o tom</param>
        /// <returns>A nota com o tom alterado</returns>
        public static string MudarTomNota(string pAcord, int pEscala = 1)
        {
            string nota, acord, retorno;
            bool heMatrizB = false;

            acord = pAcord;

            if (acord.Trim().Length == 0)
                return pAcord;

            if (!Regex.IsMatch(pAcord, regFinal))
                return pAcord;

            if (acord.Trim().Length == 1)
                nota = acord;
            else
            {
                if ("#,b".Contains(acord.Trim().Substring(1, 1)))
                    nota = acord.Trim().Substring(0, 2);
                else
                    nota = acord.Trim().Substring(0, 1);
            }

            int indice = matrizS.IndexOf(nota);

            if (indice == -1)
            {
                indice = matrizB.IndexOf(nota);

                if (indice == -1)
                    return pAcord;

                heMatrizB = true;
            }

            if (indice >= 0)
                indice += pEscala;

            if (indice > 11)
                indice = 0;

            if (indice < 0)
                indice = 11; 

            if (heMatrizB)
                retorno = acord.Replace(nota, matrizB[indice]);
            else
                retorno = acord.Replace(nota, matrizS[indice]);

            return retorno;

        }
    }
}
