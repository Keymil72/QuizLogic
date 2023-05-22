using DeepL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizLogic.Logic
{
    internal class TranslatorDeepl
    {
        public string Translate(string toTranslate)
        {
            var authKey = "033edd9c-ca89-f3e0-cb77-4eb75c081e09:fx";
            var translator = new Translator(authKey);
            var translatedText = translator.TranslateTextAsync(
            toTranslate,
            null,
            LanguageCode.Polish);
            return translatedText.Result.ToString();
        }
    }
}
