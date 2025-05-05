fn main() {
    let name = String::from("Welt");

    // Immutable borrow
    greet(&name);

    // Mutable borrow
    let mut message = String::from("Original");
    update_message(&mut message);
    println!("Aktualisierter Wert: {}", message);

    // Ownership
    let consumed = take_ownership(name);
    println!("Variable wieder zurück erhalten: {}", consumed);

    // println!("Name is: {}", name); // ❌ Wir haben auf das ursprüngliche `name` keinen Zugriff mehr
}

fn greet(name: &String) {
    println!("Hallo, {}!", name);
}

fn update_message(msg: &mut String) {
    msg.push_str(" + aktualisiert");
}

fn take_ownership(s: String) -> String {
    println!("Übernahme der Variable: {}", s);
    s // Rückgabe um das Ownership aufzugeben
}
