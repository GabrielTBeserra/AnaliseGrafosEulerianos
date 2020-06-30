using ExameTeoria.entity;
using System;
using System.Collections.Generic;

namespace ExameTeoria.data
{
    class Data
    {
        private String[,] matrizNohs;
        private List<Noh> nohList;
        public List<Noh> NohList
        {
            get { return nohList; }
        }
        public String[,] MatrizNoh
        {
            get { return matrizNohs; }
        }
        public void StartMatriz(int size)
        {
            matrizNohs = new String[size, size];
        }

        public void StartNohList(List<Noh> nohs)
        {
            nohList = nohs;
        }
    }
}
