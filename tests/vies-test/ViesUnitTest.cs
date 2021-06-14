/*
   Copyright 2017-2019 Adrian Popescu.
   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at
       http://www.apache.org/licenses/LICENSE-2.0
   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the spevatic language governing permissions and
   limitations under the License.
*/

using System.Threading.Tasks;
using Xunit;

namespace Padi.Vies.Test
{

    [Collection("ViesCollection")]
    public class ViesUnitTest
    {
        private readonly ViesManagerFixture _fixture;
        public ViesUnitTest(ViesManagerFixture fixture)
        {
            _fixture = fixture;
        }

        
         [Theory]
         [InlineData("AT U12345678","ATU12345678")]
         [InlineData("  ATU12345678","ATU12345678")]
         [InlineData("AT - -U12345678","ATU12345678")]
         [InlineData("at-U-12345678 ","ATU12345678")]
         [InlineData("GR12345678 ","EL12345678")]
         [InlineData("DE 123.456.789. ","DE123456789")]
        public void Should_Sanitize_Vat(string inputVatNumber, string expectedVatNumber)
        {
           Assert.Equal(expectedVatNumber,inputVatNumber.Sanitize());
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("123")]
        [InlineData("K99999999L")] //Albania
        [InlineData("CHE-123.456.788 ")]
        public async Task Should_Throw_ViesValidationException(string vat)
        {
            await Assert.ThrowsAsync<ViesValidationException>(() => _fixture.ViesManager.IsActive(vat));
        }

        [Theory]
        [InlineData("BE123456789")]
        [InlineData("BE897221791")]
        [InlineData(" BE0897221791")]
        [InlineData(" BE1897221789")]
        [InlineData(" BE2897221888")]
        [InlineData(" BE3897221987")]
        [InlineData(" BE4897222086")]
        [InlineData(" BE5897222185")]
        [InlineData(" BE6897222284")]
        [InlineData(" BE7897222383")]
        [InlineData(" BE8897222482")]
        [InlineData(" BE9897222581")]
        [InlineData(" BEa897222680")]
        [InlineData(" BE8a97222680")]
        [InlineData(" BE89a7222680")]
        [InlineData(" BE897a222680")]
        [InlineData(" BE8972a22680")]
        [InlineData(" BE89722a2680")]
        [InlineData(" BE897222a680")]
        [InlineData(" BE8972226a80")]
        [InlineData(" BE89722268a0")]
        [InlineData(" BE897222680a")]
        [InlineData(" BE1602602623")]
        [InlineData(" BE1400521335")]
        [InlineData(" BE1400521330")]
       
        [InlineData(" BE1400004463")]
        [InlineData(" BE0603601206")]
        [InlineData(" BE603601206")]
        [InlineData(" BE60260262")]
        [InlineData("IE 123")]
        [InlineData("ATU1234567")]
        [InlineData("BE012345678")]
        [InlineData("BG1234567")]
        [InlineData("CY1234567X")]
        [InlineData("CZ1234567")]
        [InlineData("DK10000030")]
        [InlineData("DK1234567")]
        [InlineData("EE12345678")]
        [InlineData("EL12345678")]
        [InlineData("ESX1234567")]
        [InlineData("FI1234567")]
        [InlineData("   FR00300076967")]
        [InlineData("   fr90000000027")]
        [InlineData("   fr17000000037")]
        [InlineData("   FR41000000047")]
        [InlineData("   FR01000000157")]
        [InlineData("   FR19000000068")]
        [InlineData("GB99999997")]
        [InlineData("HU1234567")]
        [InlineData("HR1234567890")]
        [InlineData("IE123456X")]
        [InlineData("IT1234567890")]
        [InlineData("LT12345678")]
        [InlineData("LU1234567")]
        [InlineData("LU10000350")]
        [InlineData("LV1234567890")]
        [InlineData("MT1234567")]
        [InlineData("NL12345678B12")]
        [InlineData("PL123456789")]
        [InlineData("PT12345678")]
        [InlineData("RO4197779")]
        [InlineData("RO1")]
        [InlineData("RO11198698")]
        [InlineData("RO99907")]
        [InlineData("RO18")]
        [InlineData("SE12345678901")]
        [InlineData("SE556188840301")]
        [InlineData("SE000000003301")]
        [InlineData("SI1234567")]
        [InlineData("SI05936241")]
        [InlineData("SK5407062531")]
        [InlineData("SK7020001680")]
        [InlineData("NL010000445B01")]
        [InlineData("NL000000025B01")]
        [InlineData("NL000000035B01")]
        [InlineData("NL000000045B01")]
        [InlineData("NL000000205B01")]
        [InlineData("NL123456789B14")]
        public void Should_Not_Validate_Vat(string vatNumber)
        {
            Assert.False(ViesManager.IsValid(vatNumber).IsValid);
        }

        [Theory]
        [InlineData("LU10000356")]
        [InlineData("PL1132191233 ")]
        [InlineData("PT100000037")]
        [InlineData("RO8440074")]
        [InlineData("RO4107779")]
        [InlineData("RO00099908")]
        [InlineData("RO0000099908")]
        [InlineData("   FR00000000190")]
        [InlineData("   FR00300076965")]
        [InlineData("   FR00303656847")]
        [InlineData("   FR01000000158")]
        [InlineData("   FR03552081317")]
        [InlineData("   FR03512803495")]
        [InlineData("   FR03784359069")]
        [InlineData("   FR04494487341")]
        [InlineData("   FR05442977302")]
        [InlineData("   FR17000000034")]
        [InlineData("   FR19000000067")]
        [InlineData("   FR43000000075")]
        [InlineData("   FR47000000141")]
        [InlineData("   FR48000000109")]
        [InlineData("   FR54000000208")]
        [InlineData("   FR13393892815")]
        [InlineData("   FR14722057460")]
        [InlineData("   FR20562016774")]
        [InlineData("   FR25000000166")]
        [InlineData("   FR22528117732")]
        [InlineData("   FR25432701258")]
        [InlineData("   FR27514868827")]
        [InlineData("   FR29312010820")]
        [InlineData("   FR31387589179")]
        [InlineData("   FR38438710865")]
        [InlineData("   FR39412658767")]
        [InlineData("   FR40303265045")]
        [InlineData("   FR40391895109")]
        [InlineData("   FR40402628838")]
        [InlineData("   FR41000000042")]
        [InlineData("   FR41343848552")]
        [InlineData("   FR42403335904")]
        [InlineData("   FR42504207853")]
        [InlineData("   FR44527865992")]
        [InlineData("   FR45395080138")]
        [InlineData("   FR45542065305")]
        [InlineData("   FR46400477089")]
        [InlineData("   FR47323875187")]
        [InlineData("   FR53418304010")]
        [InlineData("   FR55440243988")]
        [InlineData("   FR55480081306")]
        [InlineData("   FR55338966385")]
        [InlineData("   FR56439795816")]
        [InlineData("   FR57609803416")]
        [InlineData("   FR58399360817")]
        [InlineData("   FR58499528255")]
        [InlineData("   FR61300986619")]
        [InlineData("   FR61954506077")]
        [InlineData("   FR64518539093")]
        [InlineData("   FR65489465542")]
        [InlineData("   FR67000000083")]
        [InlineData("   FR71383076817")]
        [InlineData("   FR72000000117")]
        [InlineData("   FR73000000182")]
        [InlineData("   FR74532287844")]
        [InlineData("   FR82494628696")]
        [InlineData("   FR82542065479")]
        [InlineData("   FR83404833048")]
        [InlineData("   FR85418228102")]
        [InlineData("   FR88414997130")]
        [InlineData("   FR89540090917")]
        [InlineData("   FR90000000026")]
        [InlineData("   FR90524670213")]
        [InlineData("   FR96000000125")]
        [InlineData("   FRA0123456789")]
        [InlineData("   FR0A012345678")]
        [InlineData("   FRAB012345678")]
        [InlineData("PT 980526779")]
        [InlineData(" BE0000200334")]
        [InlineData("SK2120046819")]
        [InlineData("LT684289716")]
        [InlineData("LT100003346713")]
        [InlineData("LT100000009017")]
        [InlineData("LT100000031710")]
        [InlineData("LT100001410314")]
        [InlineData("LT100001647810")]
        [InlineData("LT100002247911")]
        [InlineData("LT100002640213")]
        [InlineData("LT100002992518")]
        [InlineData("LT100003099412")]
        [InlineData("LT100003222911")]
        [InlineData("LT100003776115")]
        [InlineData("LT100003806615")]
        [InlineData("LT100004463513")]
        [InlineData("LT100005808219")]
        [InlineData("LT100005772517")]
        [InlineData("LT100005847815")]
        [InlineData("LT100006555419")]
        [InlineData("LT100006615910")]
        [InlineData("LT100006688411")]
        [InlineData("LT100006852615")]
        [InlineData("LT100007390914")]
        [InlineData("LT100008061513")]
        [InlineData("LT100119219")]
        [InlineData("LT104019515")]
        [InlineData("LT108940716")]
        [InlineData("LT115521113")]
        [InlineData("LT105672113")]
        [InlineData("LT115184219")]
        [InlineData("LT119515314")]
        [InlineData("LT119513417")]
        [InlineData("LT119505811")]
        [InlineData("LT119502413")]
        [InlineData("LT119508113")]
        [InlineData("LT119517219")]
        [InlineData("LT120212314")]
        [InlineData("LT120296515")]
        [InlineData("LT205052113")]
        [InlineData("LT205458414")]
        [InlineData("LT208640716")]
        [InlineData("LT210811811")]
        [InlineData("LT213179412")]
        [InlineData("LT238708219")]
        [InlineData("LT239056314")]
        [InlineData("LT243857314")]
        [InlineData("LT245702113")]
        [InlineData("LT246655314")]
        [InlineData("LT254096515")]
        [InlineData("LT258223515")]
        [InlineData("LT290061371314")]
        [InlineData("LT321389515")]
        [InlineData("LT330214917")]
        [InlineData("LT331842113")]
        [InlineData("LT351634917")]
        [InlineData("LT408382716")]
        [InlineData("LT458248716")]
        [InlineData("LT530091413")]
        [InlineData("LT566098412")]
        [InlineData("LT852320917")]
        [InlineData("LT907560811")]
        [InlineData("NL010000446B01")]
        [InlineData("NL000000024B01")]
        [InlineData("NL000000036B01")]
        [InlineData("NL000000048B01")]
        [InlineData("NL000000206B01")]
        [InlineData("NL000000061B01")]
        [InlineData("NL000000073B01")]
        [InlineData("NL000000085B01")]
        [InlineData("NL000000103B01")]
        [InlineData("NL000000115B01")]
        [InlineData("NL000000127B01")]
        [InlineData("NL000000140B01")]
        [InlineData("NL000000152B01")]
        [InlineData("NL000000164B01")]
        [InlineData("NL000000188B01")]
        [InlineData("NL001079293B01")]
        [InlineData("NL001368023B01")]
        [InlineData("NL003156709B01")]
        [InlineData("NL004909665B07")]
        [InlineData("NL005033019B01")]
        [InlineData("NL006292227B01")]
        [InlineData("NL121745417B01")]
        [InlineData("NL128297906B01")]
        [InlineData("NL147804668B01")]
        [InlineData("NL173389909B01")]
        [InlineData("NL208560129B01")]
        [InlineData("NL800272912B01")]
        [InlineData("NL805332674B01")]
        [InlineData("NL805969317B01")]
        [InlineData("NL806825790B01")]
        [InlineData("NL806925206B01")]
        [InlineData("NL809442127B01")]
        [InlineData("NL810195835B01")]
        [InlineData("NL810876334B01")]
        [InlineData("NL813195779B01")]
        [InlineData("NL814170511B01")]
        [InlineData("NL815216002B01")]
        [InlineData("NL815498093B01")]
        [InlineData("NL818152011B01")]
        [InlineData("NL818793120B01")]
        [InlineData("NL818937841B01")]
        [InlineData("NL822502975B01")]
        [InlineData("NL822667800B01")]
        [InlineData("NL822754812B01")]
        [InlineData("NL823363247B01")]
        [InlineData("NL123456789B13")]
        [InlineData("NL002101624B69")]
        public void Should_Validate_Vat(string vatNumber)
        {
            Assert.True(ViesManager.IsValid(vatNumber).IsValid);
        }
    }
}