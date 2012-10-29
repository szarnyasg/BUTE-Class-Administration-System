using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Database_Design
{
  class Program
  {
    static void Main(string[] args)
    {
      using (TerembeosztoEntitasok ctx = new TerembeosztoEntitasok())
      {
        var terem = new Terem();
        terem.Nev = "V2.637";
        terem.Gepek_szama = 20;
        terem.Ulohelyek_szama = 25;

        ctx.TeremSet.AddObject(terem);
        ctx.SaveChanges();
      }
    }    
  }
}
