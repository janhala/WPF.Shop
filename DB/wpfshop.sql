-- phpMyAdmin SQL Dump
-- version 4.0.10.20
-- https://www.phpmyadmin.net
--
-- Počítač: localhost
-- Vygenerováno: Čtv 12. dub 2018, 17:49
-- Verze serveru: 5.5.58-38.10
-- Verze PHP: 5.3.3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Databáze: `halaja14`
--

-- --------------------------------------------------------

--
-- Struktura tabulky `wpfshop_kategorie`
--

CREATE TABLE IF NOT EXISTS `wpfshop_kategorie` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `NazevKategorie` text COLLATE utf8_czech_ci NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci AUTO_INCREMENT=4 ;

--
-- Vypisuji data pro tabulku `wpfshop_kategorie`
--

INSERT INTO `wpfshop_kategorie` (`ID`, `NazevKategorie`) VALUES
(1, 'Mobilní telefony'),
(2, 'Počítače'),
(3, 'Televize');

-- --------------------------------------------------------

--
-- Struktura tabulky `wpfshop_objednavka`
--

CREATE TABLE IF NOT EXISTS `wpfshop_objednavka` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `IDuzivatele` int(11) NOT NULL,
  `cisloObjednavky` int(11) NOT NULL,
  `typDopravy` int(11) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci AUTO_INCREMENT=12 ;

-- --------------------------------------------------------

--
-- Struktura tabulky `wpfshop_objednavka_zbozi`
--

CREATE TABLE IF NOT EXISTS `wpfshop_objednavka_zbozi` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `IDobjednavky` int(11) NOT NULL,
  `IDzbozi` int(11) NOT NULL,
  `mnozstviZbozi` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci AUTO_INCREMENT=5 ;

-- --------------------------------------------------------

--
-- Struktura tabulky `wpfshop_uzivatel`
--

CREATE TABLE IF NOT EXISTS `wpfshop_uzivatel` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Email` text COLLATE utf8_czech_ci NOT NULL,
  `PIN` int(11) NOT NULL,
  `Telefon` int(11) NOT NULL,
  `Jmeno` text COLLATE utf8_czech_ci NOT NULL,
  `Prijmeni` text COLLATE utf8_czech_ci NOT NULL,
  `UliceCP` text COLLATE utf8_czech_ci NOT NULL,
  `Obec` text COLLATE utf8_czech_ci NOT NULL,
  `PSC` int(11) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci AUTO_INCREMENT=4 ;

-- --------------------------------------------------------

--
-- Struktura tabulky `wpfshop_zbozi`
--

CREATE TABLE IF NOT EXISTS `wpfshop_zbozi` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `NazevZbozi` text COLLATE utf8_czech_ci NOT NULL,
  `Cena` int(11) NOT NULL,
  `CenaPredSlevou` int(11) NOT NULL,
  `Popis` text COLLATE utf8_czech_ci NOT NULL,
  `PocetKusuSkladem` int(11) NOT NULL,
  `KategorieZbozi` int(11) NOT NULL,
  `Vyprodej` int(11) NOT NULL,
  `FotoZbozi` text COLLATE utf8_czech_ci NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci AUTO_INCREMENT=6 ;

--
-- Vypisuji data pro tabulku `wpfshop_zbozi`
--

INSERT INTO `wpfshop_zbozi` (`ID`, `NazevZbozi`, `Cena`, `CenaPredSlevou`, `Popis`, `PocetKusuSkladem`, `KategorieZbozi`, `Vyprodej`, `FotoZbozi`) VALUES
(1, 'Samsung Galaxy J5 (2016) LTE, černá', 4990, 6313, 'Chytrý telefon Samsung Galaxy J5 (2016) Dual SIM proti svému předchůdci přichází s řadou vylepšení. Narostla nám úhlopříčka Super AMOLED displeje, kapacita operační a interní paměti, kapacita baterie, vylepšeny jsou fotoaparáty a to vše je zabaleno, místo plastu, v krásném kovovém designu. Galaxy J5 (2016) představuje kombinaci solidní konstrukce, pěkného výkonu a skvělých funkcí pro fotografie, videa a oblíbená selfie.', 3, 1, 1, 'https://www.euronics.cz/image/productgallery/800x800/954902.jpg'),
(2, 'Apple iPhone SE 32GB, šedá', 12990, 0, 'Nejnovější chytrý telefon Apple iPhone SE se vrací ke kořenům klasického kompaktního designu 4“ telefonu jak ho znáte z dob iPhone 5s. Ovšem uvnitř najdete ty nejnovější technologie, které znáte z iPhone 6s. Opět si můžete užívat krásu Retina displeje, oblíbené kamery iSight a FaceTime HD, rychlé připojení a samozřejmě skvělý intuitivní operační systém iOS ve verzi 9. V krásném a kompaktním designu tak získáte telefon nabitý výkonem z dílen Apple.', 66, 1, 1, 'https://interlink-static0.tsbohemia.cz/apple-iphone-5s-16gb-sedy_ien184056.jpg'),
(3, 'Honor 8, modrá', 9990, 11028, 'Naváže Honor 8 na úspěch modelů 6 a 7? Těžko o tom pochybovat, svou výbavou a zajímavou cenou má našlápnuto k úspěchu. Stejně jako předchůdci je bratrem top modelu ze stáje Huawei, v tomto případě P9. Vstupte do světa mobilní fotografie na nové úrovni. Zadní fotoaparát s dvojicí snímačů je stejně jako u P9 opravdovou špičkou. A na špičku patří telefon Honor 8 také svým výkonem. Nadčasová elegance, velká 5.2'''' obrazovka s úchvatnými barvami, rychlost 4G, systém Android 6.0 a štíhlý design smartphone doslova berou dech. Vysoký výkon smartphonu dodává extrémně rychlý 8jádrový procesor za přispění 4 GB paměti RAM. Získejte eleganci a výkon za příjemnou cenu v podobě Honor 8.', 888, 1, 1, 'https://cdn.electroworld.cz/images/img-large/4/516694.jpg'),
(4, 'Lenovo IdeaCentre AiO 510-23', 19999, 0, 'Bavte se a pracujte s tenkým a elegantním all-in-one počítačem Lenovo IdeaCentre AiO 510. Je charakteristický krásným, bezrámovým displejem, zvládne i náročné požadavky a s přehledem splní vaše očekávání v oblasti zábavy. IdeaCentre AiO 510 se stane nejen výkonným společníkem, ale také ozdobou interiéru.', 10, 2, 0, 'https://d1ova16yly6r23.cloudfront.net/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/l/e/lenovo-ideacentre-aio-510-22-hero1_result.jpg');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
