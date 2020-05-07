using IndividualLessons.Models;

namespace IndividualLessons.Services
{
    public class MocStringRepository : IStringRepository
    {
        // Объявляем временную модель
        private StringsEssential _strings;
        
        // Exercise 1.1 Method
        /// <summary>
        /// Method get string, format this and return
        /// </summary>
        /// <param name="capitalizeFormattingText">Input string value</param>
        /// <returns>Converted string inside the model</returns>
        public StringsEssential GetStringCapitalizeFormat(string capitalizeFormattingText)
        {
            // Создаём экземпляр класса временной модели
            _strings = new StringsEssential();

            // Переводим все буквы в нижний регистр и создаём массив предложений, разделяя его объекты по точке
            var tempVar = capitalizeFormattingText.ToLower().Split('.');

            // Проходим по всем элементам массива
            foreach (var item in tempVar)
            {
                // Записываем значение элемента во временную переменную
                // Как мы знаем, элементы цикла foreach доступны только для чтения
                var temp = item;

                // Проверяем, если начинается с пробела
                if (temp.StartsWith(" "))
                    // Удаляем пробел
                    temp = temp.Remove(0, 1);
                
                // Если элемент пустой (это может быть только песледний элемент массива)
                if (temp == "")
                    // Завершаем цикл
                    break;

                // Делаем первую букву предложения заглавной и добавляем к ней оставшуюся часть строки
                // Проверяя, если длинна строки больше 1 символа, если меньше, то ни добавляем ничего
                temp = temp.Substring(0, 1).ToUpper() + (temp.Length > 1 ? temp.Substring(1) : "");

                // Добавляем точку и пробел в конец предложения
                temp = $"{temp}. ";

                // Записываем результат в модель
                _strings.ConvertedString += temp;
            }

            // Добавляем данные во временную модель
            _strings.FunctionEnum = FunctionEnum.Capitalize;

            // Возвращаем временную модель
            return _strings;
        }

        // Exercise 1.2 Method
        /// <summary>
        /// The method get character count
        /// </summary>
        /// <param name="originalString">Input string value</param>
        /// <returns>Count inside the model</returns>
        public StringsEssential GetWordsCount(string originalString)
        {
            // Инициализируем временную модель
            _strings = new StringsEssential();

            // Объявляем временную переменную для манипуляций с текстом
            var tempString = originalString;

            // Убираем из текста все пробелы
            tempString = tempString.Replace(" ", "");

            // Заполняем временную модель данными
            _strings.CharCount = tempString.Length;
            _strings.FunctionEnum = FunctionEnum.WordCount;

            // Возвращаем модель
            return _strings;
        }

        public StringsEssential StartAndFinishChar(char startEndChar, string originalString)
        {
            _strings = new StringsEssential();

            var tempString = originalString.ToLower()
                .Replace("–", "")
                .Replace("!", "")
                .Replace(".", "")
                .Split(' ');

            foreach (var item in tempString)
            {
                if (item.StartsWith(startEndChar.ToString().ToLower()) && item.EndsWith(startEndChar.ToString().ToLower()))
                {
                    _strings.CharCount += 1;
                    _strings.ConvertedString += $"'{item}'   ";
                }
            }

            if (string.IsNullOrWhiteSpace(_strings.ConvertedString))
                _strings.ConvertedString = $"Words not contain char in start and end '{startEndChar}'";

            _strings.FunctionEnum = FunctionEnum.SomeWordStartFinish;
            _strings.WordStartEndCharacter = startEndChar;

            return _strings;
        }

        // Exercise 1.4
        public StringsEssential SomeWordsCount(string searchingWord, string originalString)
        {
            _strings = new StringsEssential();

            var tempString = originalString.ToLower()
                .Replace("-", "")
                .Replace(".", "")
                .Replace("?", "")
                .Replace(",", "")
                .Replace(":", "")
                .Split(' ');

            foreach (var item in tempString)
            {
                if (item.Contains(searchingWord))
                    _strings.CharCount += 1;
            }

            _strings.ConvertedString = searchingWord;
            _strings.FunctionEnum = FunctionEnum.SomeWordsCount;

            return _strings;
        }

        public StringsEssential ContainWord(string originalString)
        {
            _strings = new StringsEssential();

            var tempString = originalString.ToLower()
                .Replace("-", "")
                .Replace(".", "")
                .Replace("?", "")
                .Replace(",", "")
                .Replace(":", "")
                .Replace(" ", "")
                .ToCharArray();

            foreach (var item in tempString)
            {
                if (!_strings.CharacterDictionary.ContainsKey(item))
                {
                    _strings.CharacterDictionary.Add(item, 1);
                }
                else
                {
                    _strings.CharacterDictionary[item] += 1;
                }
            }

            _strings.FunctionEnum = FunctionEnum.ContainWord;

            return _strings;
        }

        public StringsEssential ReplaceWord(string originalString, string currentWord, string replacingWord)
        {
            _strings = new StringsEssential();

            var tempString = originalString;

            tempString = tempString.Replace(currentWord, replacingWord);

            _strings.ConvertedString = tempString;
            _strings.FunctionEnum = FunctionEnum.ReplaceWord;

            return _strings;
        }
    }
}
