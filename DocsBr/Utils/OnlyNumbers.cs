using System;

namespace DocsBr.Utils
{
    public class OnlyNumbers
    {
        private string value;

        public OnlyNumbers(string value)
        {
            string onlyNumber = "";
            foreach (char s in value)
            {
                if (Char.IsDigit(s))
                {
                    onlyNumber += s;
                }
            }
            this.value = onlyNumber.Trim();
        }

        public OnlyNumbers WithZerosToTheLeft(int minSize)
        {
            if (HasAnyNonZero() == false) 
                return this;

            if (this.value.Length >= minSize)
                return this;

            // Calcula quantos zeros precisam ser adicionados
            int zerosNeeded = minSize - this.value.Length;

            // Cria uma nova string com zeros à esquerda seguidos pelo valor original
            this.value = new string('0', zerosNeeded) + this.value;

            return this;
        }

        public override string ToString()
        {
            return this.value;
        }

        private bool HasAnyNonZero()
        {
            foreach (char s in value)
            {
                if (s != '0') return true;
            }

            return false;
        }
    }
}
