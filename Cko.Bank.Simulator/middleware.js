module.exports = (req, res, next) => {

    const statusCodes = ["Pending", "Paid", "Declined"];

    if (req.method == 'POST')
    {
        req.body.status = statusCodes[Math.floor(Math.random() * statusCodes.length)];;
    }
    next()
  }