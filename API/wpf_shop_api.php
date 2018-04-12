<?php
header('Content-Type: text/json');
include("../connect.php");
$method = $_SERVER['REQUEST_METHOD'];
if($method === 'GET'){
    if (isset($_GET["getAllCategories"])) {
        $select_from_db = $conn->prepare("SELECT * FROM wpfshop_kategorie");
        $select_from_db->execute();
        $json_object = $select_from_db->fetchAll(PDO::FETCH_ASSOC);

        if(!empty($json_object)){
            echo json_encode($json_object);
        }
    } elseif (isset($_GET["getAllProducts"])) {
        $select_from_db = $conn->prepare("SELECT * FROM wpfshop_zbozi");
        $select_from_db->execute();
        $json_object = $select_from_db->fetchAll(PDO::FETCH_ASSOC);

        if(!empty($json_object)){
            echo json_encode($json_object);
        }
    } elseif (isset($_GET["getProductsWhereCategoryIs"])) {
        $select_from_db = $conn->prepare("SELECT * FROM wpfshop_zbozi WHERE KategorieZbozi = :KategorieZbozi");
        $select_from_db->execute(array(':KategorieZbozi'=>$_GET['category']));
        $json_object = $select_from_db->fetchAll(PDO::FETCH_ASSOC);

        if(!empty($json_object)){
            echo json_encode($json_object);
        }
    } elseif (isset($_GET["GetWhereIDIs"])) {
        $select_from_db = $conn->prepare("SELECT * FROM wpfshop_zbozi WHERE ID = :ID");
        $select_from_db->execute(array(':ID'=>$_GET['productID']));
        $json_object = $select_from_db->fetchAll(PDO::FETCH_ASSOC);

        if(!empty($json_object)){
            echo json_encode($json_object[0]);
        }
    } elseif (isset($_GET["GetAllIDs"])) {
        $select_from_db = $conn->prepare("SELECT ID FROM wpfshop_uzivatel ORDER BY ID DESC");
        $json_object = $select_from_db->fetchAll(PDO::FETCH_ASSOC);

        if(!empty($json_object)){
            echo json_encode($json_object);
        }
    } elseif (isset($_GET["CheckPIN"])) {
        $select_from_db = $conn->prepare("SELECT PIN FROM wpfshop_uzivatel INNER JOIN wpfshop_objednavka ON wpfshop_objednavka.IDuzivatele = wpfshop_uzivatel.ID WHERE CisloObjednavky = :CisloObjednavky LIMIT 1");
        $select_from_db->execute(array(':ID'=>$_GET['productID']));
        $json_object = $select_from_db->fetchAll(PDO::FETCH_ASSOC);

        if(!empty($json_object)){
            echo json_encode($json_object);
        }
    } elseif (isset($_GET["GetWhereOrderNumber"])) {
        $select_from_db = $conn->prepare("SELECT * FROM wpfshop_objednavka WHERE cisloObjednavky = :cisloObjednavky");
        $select_from_db->execute(array(':cisloObjednavky'=>$_GET['cisloObjednavky']));
        $json_object = $select_from_db->fetchAll(PDO::FETCH_ASSOC);

        if(!empty($json_object)){
            echo json_encode($json_object);
        }
    } elseif (isset($_GET["GetWhereOrderID"])) {
        $select_from_db = $conn->prepare("SELECT * FROM wpfshop_objednavka_zbozi WHERE IDobjednavky = :IDobjednavky");
        $select_from_db->execute(array(':IDobjednavky'=>$_GET['IDobjednavky']));
        $json_object = $select_from_db->fetchAll(PDO::FETCH_ASSOC);

        if(!empty($json_object)){
            echo json_encode($json_object);
        }
    }
} elseif ($method === 'POST') {
    if (isset($_GET["saveNewOrder"])) {
        $data = json_decode(file_get_contents("php://input"), true);

        if(!empty($data)){
            $sql = $conn->prepare("INSERT into wpfshop_objednavka (IDuzivatele, cisloObjednavky, typDopravy) VALUES(?, ?, ?)");
            $insert = $sql->execute(array(
                $data['IDuzivatele'],
                $data['cisloObjednavky'],
                $data['typDopravy']
            ));
        }
    } elseif (isset($_GET["saveNewOrderProduct"])) {
        $data = json_decode(file_get_contents("php://input"), true);

        if(!empty($data)){
            $sql = $conn->prepare("INSERT into wpfshop_objednavka_zbozi (IDobjednavky, IDzbozi, mnozstviZbozi) VALUES(?, ?, ?)");
            $insert = $sql->execute(array(
                $data['IDobjednavky'],
                $data['IDzbozi'],
                $data['mnozstviZbozi']
            ));
        }
    } elseif (isset($_GET["saveNewUser"])) {
        $data = json_decode(file_get_contents("php://input"), true);

        if(!empty($data)){
            $sql = $conn->prepare("INSERT into wpfshop_uzivatel (Email, PIN, Telefon, Jmeno, Prijmeni, UliceCP, Obec, PSC) VALUES(?, ?, ?, ?, ?, ?, ?, ?)");
            $insert = $sql->execute(array(
                $data['Email'],
                $data['PIN'],
                $data['Telefon'],
                $data['Jmeno'],
                $data['Prijmeni'],
                $data['UliceCP'],
                $data['Obec'],
                $data['PSC']
            ));
        }
    }
} elseif($method === 'PUT') {
    if (isset($_GET["addOrModifyQaA"])) {
        $data = json_decode(file_get_contents("php://input"), true);

        if(!empty($data)){
            $sql = $conn->prepare("UPDATE multiquiz_QaA SET category_name_id = ?, question = ?, correct_answer = ?, answer_A = ?, answer_B = ?, answer_C = ?, answer_D = ?, approved = ?, voted_for = ?, voted_against = ? WHERE id = ?");
            $update = $sql->execute(array(
                $data['Category_name_id'],
                $data['Question'],
                $data['Correct_answer'],
                $data['Answer_A'],
                $data['Answer_B'],
                $data['Answer_C'],
                $data['Answer_D'],
                $data['Approved'],
                $data['Voted_for'],
                $data['Voted_against'],
                $data['Id']
            ));
        }
    }
} elseif($method === 'DELETE') {
    if (isset($_GET['deleteQaA'])){
        $sql = $conn->prepare("DELETE FROM wpfshop_objednavka WHERE cisloObjednavky = :cisloObjednavky");
        $db_dlt = $sql->execute(array(':cisloObjednavky'=>$_GET['cisloObjednavky']));
        /*if($db_dlt){
            echo "Zaznam s id ". $_GET['cisloObjednavky'] ." byl uspesne odstranen.";
        } else{
            echo 'Zaznam se nepodarilo z databaze odstranit.';
        }*/
    }
} else {
    echo "B?hem procesu nastala chyba.";
}
?>