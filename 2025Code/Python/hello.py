
choice = 0

def is_integer(value):
    try:
        int(value)
        return True
    except ValueError:
        return False

while True:
    print("1: Addition")
    print("2: Subtraction")
    print("3: Multiplication")
    print("4: Division")
    print("5: Quit")
    choice = input("Enter your choice: ")

    while not is_integer(choice):
        print("Please enter your answer as a whole number")
        choice = input("Enter your choice: ")
    
    choice = int(choice)
    
    match choice:
        case 1:
            print("Addition")
        case 2:
            print("Subtraction")
        case 3:
            print("Multiplication")
        case 4:
            print("Division")
        case 5:
            print("Quit")
        case _:
            print("Invalid Option")

    if choice == 5:
        break
