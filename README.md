# UnluCo .net bootcamp 4.Hafta Ödevi
--------------------------------------------------------------------

## Yapılanlar

* User kontroller eklenerek Kullanıcı işlemleri identity server kullanılarak Login ,register ,register manager başta olmak üzere yaratılmıştır.

* Yetkilendirme işlemleri için JWT kullanılmış kayıtlı girişte dönen acces token postman ile test edilmiş ve [authorize] alanlara başarılı bir şekilde giriş yapılmaktadır.

* Busines Layer içerisinde ResultFilter oluşturulmuş Context 'in headerina istek ve isteğin geliş zamanı string olarak yazdırılmıştır.
  
* Giriş yapan kişilerin rollerine göre BankController'da belirli HttpMethodlarına erişim sağlanamamaktadır. 

* Toplamda 4 farklı katman kullanılmış kontroller'ların içerisi olabildiğince boşaltılarak dependency injection ile çektiğimiz class'lar üzerinden işlemler yürütülmüştür.

