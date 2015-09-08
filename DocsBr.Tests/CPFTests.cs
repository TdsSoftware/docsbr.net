﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DocsBr.Tests
{
    [TestClass]
    public class CPFTests
    {
        private static string formattedCPF = "123.456.789-09";
        private static string unformattedCPF = "12345678909";
        private static string invalidCPF = "999.999.999-90";

        [TestMethod]
        public void TestShouldReturnCPFWithoutMask()
        {
            CPF cpf = formattedCPF;
            Assert.AreEqual<string>(unformattedCPF, cpf);
        }

        [TestMethod]
        public void TestShouldReturnCPFWithMask()
        {
            CPF cpf = unformattedCPF;
            Assert.AreEqual(formattedCPF, cpf.ComMascara());
        }

        [TestMethod]
        public void TestShouldReturnEmptyCPF()
        {
            CPF cpf = "";
            Assert.AreEqual("", cpf.ToString());
        }

        [TestMethod]
        public void TestShouldValidateCPF()
        {
            CPF cpf = formattedCPF;
            Assert.IsTrue(cpf.IsValid());
        }

        [TestMethod]
        public void TestShouldInvalidateCPF()
        {
            CPF cpf = invalidCPF;
            Assert.IsFalse(cpf.IsValid());
        }

        [TestMethod]
        public void TestShouldInvalidateCPFWhenEmpty()
        {
            CPF cpf = "";
            Assert.IsFalse(cpf.IsValid());
        }

        [TestMethod]
        public void TestShouldInvalidateCNPJWhenRepeatedDigits()
        {
            string[] invalidNumbers =
            {
                "00000000000",
                "11111111111",
                "22222222222",
                "33333333333",
                "44444444444",
                "55555555555",
                "66666666666",
                "77777777777",
                "88888888888",
                "99999999999"
            };

            foreach (CPF cpf in invalidNumbers)
            {
                Assert.IsFalse(cpf.IsValid());
            }
        }

        [TestMethod]
        public void TestShouldReturnEqualsWhenComparedFormattedAndUnformattedCPF()
        {
            CNPJ cpfWithMask = formattedCPF;
            CNPJ cpfWithoutMask = unformattedCPF;
            Assert.IsTrue(cpfWithMask.Equals(cpfWithoutMask));
        }

        [TestMethod]
        public void TestShouldReturnNotEqualsWhenComparedDifferentCPF()
        {
            CNPJ cpf1 = unformattedCPF;
            CNPJ cpf2 = invalidCPF;
            Assert.IsFalse(cpf1.Equals(cpf2));
        }
    }
}