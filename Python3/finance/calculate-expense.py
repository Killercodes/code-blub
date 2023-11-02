def calculate_expense_ratio(nav: float, aum: float, expense_ratio: float, num_units: int) -> tuple:
    """
    Calculates the amount to be deducted per annum and total expenses based on the NAV, AUM, and expense ratio of a mutual fund.

    Parameters:
    nav (float): The net asset value of the mutual fund.
    aum (float): The assets under management of the mutual fund.
    expense_ratio (float): The expense ratio of the mutual fund.
    num_units (int): The number of units held in the mutual fund.

    Returns:
    tuple: A tuple containing the amount to be deducted per annum and total expenses.
    """
    amount_deducted = (nav * num_units * expense_ratio) / 100
    total_expenses = expense_ratio * aum
    return amount_deducted, total_expenses
