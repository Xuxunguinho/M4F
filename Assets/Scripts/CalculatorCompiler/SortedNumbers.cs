/* Developed by Julio Jose de Andrade Reis
2018 All rigth reserved 
This game was created for my knowlodge test.*/
using System.Collections.Generic;
using UnityEngine;

// ReSharper disable once CheckNamespace
public class SortedNumbers  {

    /// <summary>
    /// Gera uma lista de numeros sem repetir qualquer um deles,
    /// </summary>
    /// <param name="bsn">BoardSortedNumbers </param>
    /// <returns></returns>
    public int[] Execute(BoardSortedNumbers bsn) {
               
        var generateds = new List<int>();

        var i = 0;
        while (i < bsn.Quantity)
        {
            var numeroAleatorio = Random.Range(bsn.InitRandom, bsn.FinalRandom);
            if (generateds.Contains(numeroAleatorio)) continue;
            generateds.Add(numeroAleatorio);

            i++;
        }   

        return generateds.ToArray();
    }/// <summary>
     /// Gera uma lista de numeros sem repetir qualquer um deles,
     /// </summary>
     /// <param name="init">Inicio dos aleatorios</param>
     /// <param name="final">Final dos aleatorios</param>
     /// <param name="quantity">Quantidade de aleatorios a retornar</param>
     /// <returns>int array</returns>
    public int[] Execute(int init,int final, int quantity)
    {
        var generateds = new List<int>();
        if ((final - init) < quantity)
        {
            Debug.Log("Erro na geracao de numeros");
        }
        else
        {
            var i = 0;
            while (i <quantity)
            {
                var numeroAleatorio = Random.Range(init, final);
                if (!generateds.Contains(numeroAleatorio))
                {
                    generateds.Add(numeroAleatorio);

                    i++;
                }

            }
        }
        

      

        return generateds.ToArray();
    }

    /// <summary>
    /// Gera uma lista de numeros sem repetir qualquer um deles,
    /// Este sera utilizado quando ja se tem uma lista com alguns numeros e so se quer aumentar 
    /// </summary>
    /// <param name="initN"> inicio do random ou seja dos numeros aleatorios requesitados</param>
    /// <param name="finalyN"> Fim do ramdom </param>
    /// <param name="quantityN"> Quantidadede de elementos ou resultados que deseja obter </param>
    /// <param name="lstInt"></param>
    /// <returns> int[] </returns>
    public int [] ExecuteWithException(int initN, int finalyN, int quantityN, List<int> lstInt )
    {      

        var i = 0;
        while (i < quantityN)
        {
            var numeroAleatorio = Random.Range(initN, finalyN);
            if (lstInt.Contains(numeroAleatorio)) continue;
            lstInt.Add(numeroAleatorio);

            i++;
        }

        return lstInt.ToArray();
    }

}
