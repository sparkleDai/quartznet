/* 
 * Copyright 2004-2006 OpenSymphony 
 * 
 * Licensed under the Apache License, Version 2.0 (the "License"); you may not 
 * use this file except in compliance with the License. You may obtain a copy 
 * of the License at 
 * 
 *   http://www.apache.org/licenses/LICENSE-2.0 
 *   
 * Unless required by applicable law or agreed to in writing, software 
 * distributed under the License is distributed on an "AS IS" BASIS, WITHOUT 
 * WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the 
 * License for the specific language governing permissions and limitations 
 * under the License.
 */

using System;

using NUnit.Framework;

using Quartz.Impl.Calendar;

namespace Quartz.Tests.Unit.NewTest
{
    [TestFixture]
    public class CronCalendarTest
    {
        [Test]
        public void TestCronCalendar()
        {
            string expr = string.Format("0/15 * * * * ?");
            CronCalendar calendar = new CronCalendar(expr);
            string fault = "Time was included when it was not supposed to be";
            DateTime tst = DateTime.Now.AddMinutes(2);
            tst = new DateTime(tst.Year, tst.Month, tst.Day, tst.Hour, tst.Minute, 30);
            Assert.IsFalse(calendar.IsTimeIncluded(tst), fault);

            calendar.SetCronExpressionString("0/25 * * * * ?");
            fault = "Time was not included as expected";
            Assert.IsTrue(calendar.IsTimeIncluded(tst), fault);
        }

    
    }
}
