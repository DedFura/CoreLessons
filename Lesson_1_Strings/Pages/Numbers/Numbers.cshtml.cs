using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lesson_1_Strings.Pages.Numbers
{
    public class NumbersModel : PageModel
    {
        // Так, как у нас будет возврат разных типов, то создаём свойство типа Object
        // Что делает его универсальным для всех ответов
        [BindProperty] public object Answer { get; set; }
        [BindProperty] public bool StackOverflowCheck { get; set; } // Вроде как есть класс StackOverflowException, но больше для полноценных тестов try catch,
        // и для полноценной отлакди программы, по этому такой велосипед




        public void OnGet()
        {

        }

        // Создаём метод обработки формы
        // Хочу заметить, что префикс OnPost ОБЯЗАТЕЛЕН! Иначе, метод не будет обрабатывать POST запросы
        // Передаём методу 2 параметра из формы, по умолчанию они могут быть NULL
        public void OnPostExampleMethod(int? firstNum, int? secondNum)
        {
            // Проверяем, если параметры имеют какие-либо значения, то выполняем логику
            if (firstNum != null && secondNum != null)
            {
                // Присваиваем нашему свойству ответ путём сложения 2-х чисел и приведения их явно к нужному типу.
                Answer = (long) (firstNum + secondNum);
            }
        }
        public void OnPostAdditionSbyteMethod(sbyte? firstNum, sbyte? secondNum)
        {
            if (firstNum != null && secondNum != null)
            {
                Answer = (sbyte)(firstNum + secondNum);
                if ((firstNum + secondNum) > sbyte.MaxValue) StackOverflowCheck = true;
            }
        }
        public void OnPostAdditionDecimalMethod(string? firstNum, string? secondNum)
        {
            
            if (firstNum != null && secondNum != null)
            {
                decimal decFirst = decimal.Parse(firstNum, new System.Globalization.CultureInfo("ru-ru"));
                decimal decSecond = decimal.Parse(secondNum, new System.Globalization.CultureInfo("ru-ru"));
                Answer = (decimal)(decFirst+decSecond);
                if ((decFirst + decSecond) > decimal.MaxValue) StackOverflowCheck = true;
            }
        }


    }
}