const router = require('express').Router()
const User = require('../Models/User')

router.route('/register').post(async(req,res)=>{
    const {name, email, password} = req.body
    const user = {name,email,password}
    if(!name|| !email || !password){
        res.status(400).json({
            message:"Field cannot be empty"
        });
        return
    }

    try {
        await User.create(user)
        res.status(200).json({message:"User successfully created!"});
    } catch (error) {
        res.status(500).json({error: error});
    }
});

router.route('/login').post(async(req,res)=>{
    const {email,password} = req.body
    if(!email || !password){
        res.status(400).json({
            message:"Field cannot be empty"
        });
        return
    }

    try {
        const user = await User.findOne({email:email})
        res.status(200).json({user});
    } catch (error) {
        res.status(500).json({error: error});
    }
})

module.exports = router