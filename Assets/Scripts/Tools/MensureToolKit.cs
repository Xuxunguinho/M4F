/// Developed by Julio Jose de Andrade Reis
/// 2018 All rigth reserved 
/// This game was created for my knowlodge test.


// ReSharper disable once CheckNamespace
    public  class MensureToolKit 
    {
        /// <summary>
        /// this is used to  compute how math items has in side of operator [left and right] 
        /// </summary>
        /// <param name="arrayCont"> Ex : Operatores.Lenght</param>
        /// <param name="operPos"></param>
        /// <returns></returns>
        public Mensure ExecArray2Dim(int arrayCont , int operPos) {

            var m = new Mensure {RightCount = arrayCont - (operPos + 1)};
            m.LeftCount = arrayCont - m.RightCount;
            return m;
        }
                
        /// <summary>
        /// this is used to  compute how math items has in side of an Item in an lists [left and right]
        /// </summary>
        /// <param name="arrayCont"> Ex : Operatores.Lenght</param>
        /// <param name="itemPos"> Ex :  Item.Index</param>
        /// <returns></returns>
        
        public Mensure ExecArray1Dim(int arrayCont, int itemPos)
        {

            var m = new Mensure {RightCount = arrayCont - (itemPos + 1)};
            m.LeftCount = arrayCont - (m.RightCount +1);

            return m;
        }
       
    } 
