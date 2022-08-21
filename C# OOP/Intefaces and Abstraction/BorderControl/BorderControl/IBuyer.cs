using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public interface IBuyer
    {
        public void BuyFood();
        int Food { get; set; }
    }
}
